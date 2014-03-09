using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImagePalette
{
    public delegate void ImageChangedHandler(object sender);

    /// <summary>
    /// Class that does the processing.
    /// </summary>
    public class ImagePaletteProcess
    {
        private const string DataTableIndexedName = "Indexed from image";
        private const string DataTableLoadedName = "Loaded as reference";
        private const string DataTableMatchedName = "Matched colors";

        public ImagePaletteParameters Parameters { get; private set; }

        public DataTable DataTableIndexed { get; private set; }
        public DataTable DataTableLoaded { get; private set; }
        public DataTable DataTableMatched { get; private set; }

        public List<string> FileNamesExpanded { get; private set; }
        public int CurrentFileIndex { get; private set; }
        public bool CurrentImageIsProcessed { get; private set; }

        public Image CurrentImageOriginal { get; private set; }
        public Image CurrentImageIndexed { get; private set; }

        public ImagePaletteResults Results { get; private set; }

        // Events raised in this class
        public event ImageChangedHandler ImageChangedEvent;

        public ImagePaletteProcess(ImagePaletteParameters parameters)
        {
            Parameters = parameters;

            // Register for events when properties are modified
            Parameters.PropertyChanged += new PropertyChangedEventHandler(imagePaletteParameters_PropertyChanged);

            // Get the files to process
            FileNamesExpanded = new List<string>();
            GetFileNames();

            // Indexed from image
            DataTableIndexed = new DataTable(DataTableIndexedName);
            DataTableIndexed.Columns.AddRange(new DataColumn[] {
                new DataColumn(PaletteGridColumns.Color, typeof(Color)),
                new DataColumn(PaletteGridColumns.R, typeof(int)),
                new DataColumn(PaletteGridColumns.G, typeof(int)),
                new DataColumn(PaletteGridColumns.B, typeof(int)),
                new DataColumn(PaletteGridColumns.A, typeof(int)),
                new DataColumn(PaletteGridColumns.Count, typeof(int)),
                new DataColumn(PaletteGridColumns.Percentage, typeof(double)),
                new DataColumn(PaletteGridColumns.Match, typeof(Color)),
                new DataColumn(PaletteGridColumns.Distance, typeof(double))
            });

            // Matched colors from image + palette
            DataTableMatched = new DataTable(DataTableMatchedName);
            DataTableMatched.Columns.AddRange(new DataColumn[] {
                new DataColumn(PaletteGridColumns.Color, typeof(Color)),
                new DataColumn(PaletteGridColumns.R, typeof(int)),
                new DataColumn(PaletteGridColumns.G, typeof(int)),
                new DataColumn(PaletteGridColumns.B, typeof(int)),
                new DataColumn(PaletteGridColumns.A, typeof(int)),
                new DataColumn(PaletteGridColumns.Count, typeof(int)),
                new DataColumn(PaletteGridColumns.Percentage, typeof(double))
            });

            // Loaded palette
            DataTableLoaded = new DataTable(DataTableLoadedName);
            DataTableLoaded.Columns.AddRange(new DataColumn[] {
                new DataColumn(PaletteGridColumns.Color, typeof(Color)),
                new DataColumn(PaletteGridColumns.R, typeof(int)),
                new DataColumn(PaletteGridColumns.G, typeof(int)),
                new DataColumn(PaletteGridColumns.B, typeof(int)),
                new DataColumn(PaletteGridColumns.A, typeof(int))
            });

            Results = new ImagePaletteResults(parameters);
        }

        /// <summary>
        /// Given H,S,L in range of 0-1
        /// Returns a Color (RGB struct) in range of 0-255
        /// 
        /// Taken from http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
        /// </summary>
        /// <param name="h"></param>
        /// <param name="sl"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static Color HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            Color rgb = Color.FromArgb(255, Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
            return rgb;
        }

        protected void imagePaletteParameters_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.Assert(object.ReferenceEquals(sender, Parameters));

            // Util.GetMemberInfo in order to have strong typed info in case of code refactoring
            if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.ThresholdIndexed).Name))
            {
                ApplyDataTableIndexedViewFilter();
            }
            else if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.ApplyThresholdIndexed).Name))
            {
                ApplyDataTableIndexedViewFilter();
            }
            else if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.Distance).Name))
            {
                ApplyDataTableIndexedViewFilter();
            }
            else if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.ApplyThresholdDistance).Name))
            {
                ApplyDataTableIndexedViewFilter();
            }
            else if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.FileNames).Name))
            {
                GetFileNames();
                ProcessCurrent();
            }
        }

        /// <summary>
        /// Calculates the distance between two colors, adjusted for the human eye.
        /// More details on the theory here: http://www.compuphase.com/cmetric.htm
        /// Important note from the link above:
        /// This formula has results that are very close to L*u*v* (with the modified lightness curve) and, more importantly,
        /// it is a more stable algorithm: it does not have a range of colours where it suddenly gives far from optimal results.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double ColorDistance(Color c1, Color c2)
        {
            long rmean = ((long)c1.R + (long)c2.R) / 2;
            long r = (long)c1.R - (long)c2.R;
            long g = (long)c1.G - (long)c2.G;
            long b = (long)c1.B - (long)c2.B;

            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }

        public bool IsWithinDistance(Color c1, Color c2)
        {
            double distance = ColorDistance(c1, c2);
            return IsWithinDistance(distance);
        }

        public bool IsWithinDistance(double distance)
        {
            return distance <= Parameters.Distance;
        }

        /// <summary>
        /// Gets the file(s) from the Parameters and populates the necessary lists.
        /// </summary>
        private void GetFileNames()
        {
            FileNamesExpanded.Clear();
            CurrentFileIndex = 0;
            CurrentImageIsProcessed = false;
            FileNamesExpanded.AddRange(Parameters.GetExpandedFileNames());
        }

        public string CurrentFileName
        {
            get
            {
                if (FileNamesExpanded == null || FileNamesExpanded.Count == 0)
                    return null;
                return FileNamesExpanded[CurrentFileIndex];
            }
        }

        /// <summary>
        /// Loads the palette from the file specified in the parameters.
        /// </summary>
        private void LoadPalette()
        {
            DataTableLoaded.Rows.Clear();

            if (!string.IsNullOrWhiteSpace(Parameters.FileNameReference))
            {
                HashSet<Color> palette = new PaletteReader(Parameters.FileNameReference).GetPalette();
                if (palette != null && palette.Count > 0)
                {
                    foreach (Color color in palette)
                    {
                        DataRow row = DataTableLoaded.NewRow();
                        row[PaletteGridColumns.Color] = color;

                        DataTableLoaded.Rows.Add(row);
                    }
                }
            }
        }

        public HashSet<Color> GetPalette()
        {
            if (DataTableLoaded.Rows.Count == 0)
                LoadPalette();

            HashSet<Color> palette = new HashSet<Color>();
            foreach (DataRow row in DataTableLoaded.Rows)
                palette.Add((Color)row[PaletteGridColumns.Color]);

            return palette;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceReprocess"></param>
        /// <returns>Wether the process took place or it was already done.</returns>
        public bool ProcessCurrent(bool forceReprocess=false)
        {
            bool processed = false;

            if (forceReprocess || !CurrentImageIsProcessed)
            {
                if (DataTableLoaded == null || DataTableLoaded.Rows.Count == 0)
                {
                    LoadPalette();
                }

                // Calculation steps
                CalculateIndexedColors(forceReprocess);
                CalculateColorDistances(forceReprocess);
                CalculateMatchedColors(forceReprocess);

                // Update results
                List<ImagePaletteResult> fileResult = new List<ImagePaletteResult>(DataTableMatched.DefaultView.Count);
                foreach (DataRowView row in DataTableMatched.DefaultView)
                    fileResult.Add(new ImagePaletteResult((Color)row[PaletteGridColumns.Color], (int)row[PaletteGridColumns.Count]));
                Results.FileResults[CurrentFileName] = fileResult;

                // Set processed flags
                CurrentImageIsProcessed = true;
                processed = true;
            }

            return processed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ProcessNext()
        {
            bool processed = false;

            if (CurrentFileIndex < (FileNamesExpanded.Count - 1))
            {
                CurrentFileIndex++;
                CurrentImageIsProcessed = false;
                processed = ProcessCurrent();
            }

            return processed;
        }

        public bool ProcessPrevious()
        {
            bool processed = false;

            if (CurrentFileIndex > 0)
            {
                CurrentFileIndex--;
                CurrentImageIsProcessed = false;
                processed = ProcessCurrent();
            }

            return processed;
        }

        /// <summary>
        /// Gets the table with the indexed colors that pass the given threshold of number of colors from the indexed image.
        /// </summary>
        /// <param name="applyThreshold"></param>
        /// <param name="forceReprocess"></param>
        /// <returns></returns>
        private void CalculateIndexedColors(bool forceReprocess = false)
        {
            if (forceReprocess || !CurrentImageIsProcessed)
            {
                try
                {
                    // Load image
                    CurrentImageOriginal = new Bitmap(CurrentFileName);
                    if (CurrentImageOriginal == null)
                        throw new Exception("Error reading image.");

                    // Convert to indexed image to limit the number of colors being processed
                    MemoryStream bitStream = new MemoryStream();
                    CurrentImageOriginal.Save(bitStream, ImageFormat.Gif);
                    CurrentImageIndexed = new Bitmap(bitStream);
                    if (CurrentImageIndexed == null)
                        throw new Exception("Error converting to indexed image.");
                }
                finally
                {
                    // Fire event stating that images changed
                    if (ImageChangedEvent != null)
                        ImageChangedEvent(this);
                }

                // Index colors from image
                // Hashtable has faster operation than DataTable
                Bitmap image = (Bitmap)CurrentImageIndexed;
                Hashtable indexedFromImage = new Hashtable();
                int totalPixels = 0;

                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color color = image.GetPixel(x, y);
                        if (indexedFromImage[color] == null)
                            indexedFromImage[color] = 1;
                        else
                            indexedFromImage[color] = (int)indexedFromImage[color] + 1;

                        totalPixels++;
                    }
                }

                // Convert Hashtable to DataTable
                DataTableIndexed.Rows.Clear();
                foreach (DictionaryEntry entry in indexedFromImage)
                {
                    Color color = (Color)entry.Key;
                    int count = (int)entry.Value;

                    DataRow row = DataTableIndexed.NewRow();
                    row[PaletteGridColumns.Color] = color;
                    row[PaletteGridColumns.Count] = count;
                    row[PaletteGridColumns.Percentage] = (double)(count * 100) / (double)totalPixels;

                    DataTableIndexed.Rows.Add(row);
                }

                DataTableIndexed.DefaultView.Sort = PaletteGridColumns.Count + " DESC";
            }

            ApplyDataTableIndexedViewFilter();
        }

        private void CalculateColorDistances(bool forceReprocess = false)
        {
            if (forceReprocess || !CurrentImageIsProcessed)
            {
                if (DataTableIndexed == null || DataTableIndexed.Rows.Count == 0 || DataTableLoaded == null || DataTableLoaded.Rows.Count == 0)
                    throw new Exception("Need to have both the indexed and loaded colors to match by distance.");

                // Apply index threshold if necessary
                bool applyThresholdIndexed = !Parameters.ExploreMode && Parameters.ApplyThresholdIndexed;

                HashSet<Color> palette = GetPalette();
                foreach (DataRow rowIndexed in DataTableIndexed.Rows)
                {
                    if (applyThresholdIndexed && (double)rowIndexed[PaletteGridColumns.Percentage] < Parameters.ThresholdIndexed)
                        continue;  // Skip all calculations below if they're not necessary

                    Color colorIndexed = (Color)rowIndexed[PaletteGridColumns.Color];

                    Color colorMatched = Color.White;  // Just a color to initialize given Color is non-nullable
                    double distanceClosest = -1;
                    foreach (Color colorPalette in palette)
                    {
                        double distance = ColorDistance(colorIndexed, colorPalette);
                        if (IsWithinDistance(distance))
                        {
                            // Each color can potentially be matched to more than one color in the palette
                            // Keeps only the closest color
                            if (distanceClosest < 0 || distance < distanceClosest)
                            {
                                colorMatched = colorPalette;
                                distanceClosest = distance;
                            }
                        }
                    }

                    if (distanceClosest > -1)
                    {
                        rowIndexed[PaletteGridColumns.Match] = colorMatched;
                        rowIndexed[PaletteGridColumns.Distance] = distanceClosest;
                    }
                }

                string filterIndexCount = string.Format("[{0}] >= {1}", PaletteGridColumns.Percentage, Parameters.ThresholdMatched);
                string filterDistance = string.Format("[{0}] < {1}", PaletteGridColumns.Distance, Parameters.Distance);

                bool applyThresholdDistance = !Parameters.ExploreMode && Parameters.ApplyThresholdDistance;
                string filter = "";
                if (applyThresholdIndexed)
                    filter += filterIndexCount;
                if (applyThresholdDistance)
                {
                    if (applyThresholdIndexed)
                        filter += " AND ";
                    filter += filterDistance;
                }

                DataTableMatched.DefaultView.RowFilter = string.IsNullOrEmpty(filter) ? null : filter;
            }
        }

        private void CalculateMatchedColors(bool forceReprocess = false)
        {
            if (forceReprocess || !CurrentImageIsProcessed)
            {
                bool applyThresholdMatched = !Parameters.ExploreMode && Parameters.ApplyThresholdMatched;
                bool applyThresholdDistance = !Parameters.ExploreMode && Parameters.ApplyThresholdDistance;
                string filterDistance = applyThresholdDistance ? string.Format("[{0}] < {1}", PaletteGridColumns.Distance, Parameters.Distance) : null;

                // Get the rows where the matched color has been calculated
                // Sort by Matched color, which will help later in adding the number of ocurrences of each color
                DataView dvIndexed = new DataView(DataTableIndexed, filterDistance, PaletteGridColumns.Match, DataViewRowState.CurrentRows);

                // Build the table with the matched colors
                DataTableMatched.Rows.Clear();
                Color currentColor = Color.White;  // Any color since it's a non nullable object
                DataRow matchedRow = null;
                foreach (DataRowView drvIndexed in dvIndexed)
                {
                    DataRow rowIndexed = drvIndexed.Row;
                    Color newColor = (Color)rowIndexed[PaletteGridColumns.Match];

                    if (matchedRow == null || !newColor.Equals(currentColor))
                    {
                        currentColor = (Color)rowIndexed[PaletteGridColumns.Match];
                        matchedRow = DataTableMatched.NewRow();
                        matchedRow[PaletteGridColumns.Color] = currentColor;
                        matchedRow[PaletteGridColumns.Count] = (int)rowIndexed[PaletteGridColumns.Count];

                        DataTableMatched.Rows.Add(matchedRow);
                        currentColor = newColor;
                    }
                    else
                    {
                        matchedRow[PaletteGridColumns.Count] =
                            (int)matchedRow[PaletteGridColumns.Count] + (int)rowIndexed[PaletteGridColumns.Count];
                    }
                }

                string filterMatched = applyThresholdMatched ? string.Format("[{0}] < {1}", PaletteGridColumns.Count, Parameters.ThresholdMatched) : null;

                DataTableMatched.DefaultView.Sort = PaletteGridColumns.Count + " DESC";
                DataTableMatched.DefaultView.RowFilter = string.IsNullOrEmpty(filterMatched) ? null : filterMatched;
            }
        }

        private void ApplyDataTableIndexedViewFilter()
        {
            string filterIndexCount = string.Format("[{0}] >= {1}", PaletteGridColumns.Percentage, Parameters.ThresholdIndexed);
            string filterDistance = string.Format("[{0}] < {1}", PaletteGridColumns.Distance, Parameters.Distance);

            bool applyThresholdDistance = !Parameters.ExploreMode && Parameters.ApplyThresholdDistance;
            string filter = "";
            if (Parameters.ApplyThresholdIndexed)
                filter += filterIndexCount;
            if (Parameters.ApplyThresholdDistance)
            {
                if (Parameters.ApplyThresholdIndexed)
                    filter += " AND ";
                filter += filterDistance;
            }

            DataTableIndexed.DefaultView.RowFilter = string.IsNullOrEmpty(filter) ? null : filter;
        }
    }
}