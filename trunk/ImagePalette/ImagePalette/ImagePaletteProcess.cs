﻿using System;
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

        public List<string> FileNames { get; private set; }
        public int CurrentFileIndex { get; private set; }
        public bool CurrentImageIsProcessed { get; private set; }

        public Image CurrentImageOriginal { get; private set; }
        public Image CurrentImageIndexed { get; private set; }

        // Events raised in this class
        public event ImageChangedHandler ImageChangedEvent;

        public ImagePaletteProcess(ImagePaletteParameters parameters)
        {
            Parameters = parameters;

            // Register for events when properties are modified
            Parameters.PropertyChanged += new PropertyChangedEventHandler(imagePaletteParameters_PropertyChanged);

            // Get the files to process
            FileNames = new List<string>();
            GetFileNames();

            // Indexed from image
            DataTableIndexed = new DataTable(DataTableIndexedName);
            DataTableIndexed.Columns.AddRange(new DataColumn[] {
                new DataColumn(PaletteGridColumns.Color, typeof(string)),
                new DataColumn(PaletteGridColumns.R, typeof(int)),
                new DataColumn(PaletteGridColumns.G, typeof(int)),
                new DataColumn(PaletteGridColumns.B, typeof(int)),
                new DataColumn(PaletteGridColumns.A, typeof(int)),
                new DataColumn(PaletteGridColumns.Count, typeof(int)),
                new DataColumn(PaletteGridColumns.Percentage, typeof(double)),
                new DataColumn(PaletteGridColumns.Match, typeof(string)),
                new DataColumn(PaletteGridColumns.Distance, typeof(double))
            });

            // Matched colors from image + palette
            DataTableMatched = new DataTable(DataTableMatchedName);
            DataTableMatched.Columns.AddRange(new DataColumn[] {
                new DataColumn(PaletteGridColumns.Color, typeof(string)),
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
                new DataColumn(PaletteGridColumns.Color, typeof(string)),
                new DataColumn(PaletteGridColumns.R, typeof(int)),
                new DataColumn(PaletteGridColumns.G, typeof(int)),
                new DataColumn(PaletteGridColumns.B, typeof(int)),
                new DataColumn(PaletteGridColumns.A, typeof(int))
            });
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
                GetIndexedTable(Parameters.ApplyThresholdIndexed);
            }
            else if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.ApplyThresholdIndexed).Name))
            {
                GetIndexedTable(Parameters.ApplyThresholdIndexed);
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
            FileNames.Clear();
            CurrentFileIndex = 0;
            CurrentImageIsProcessed = false;

            if (!string.IsNullOrWhiteSpace(Parameters.FileName))
            {
                if (Directory.Exists(Parameters.FileName))
                {
                    // Directory
                    FileNames.AddRange(Directory.GetFiles(Parameters.FileName));
                }
                else if (File.Exists(Parameters.FileName))
                {
                    // File
                    FileNames.Add(Parameters.FileName);
                }
                // else it's neither a file nor a directory, doesn't exist
            }
        }

        public string CurrentFileName
        {
            get
            {
                if (FileNames == null || FileNames.Count == 0)
                    return null;
                return FileNames[CurrentFileIndex];
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
                        row[PaletteGridColumns.R] = color.R;
                        row[PaletteGridColumns.G] = color.G;
                        row[PaletteGridColumns.B] = color.B;
                        row[PaletteGridColumns.A] = color.A;

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
            {
                palette.Add(Color.FromArgb(
                    (int)row[PaletteGridColumns.A],
                    (int)row[PaletteGridColumns.R],
                    (int)row[PaletteGridColumns.G],
                    (int)row[PaletteGridColumns.B]));
            }

            return palette;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceReprocess"></param>
        /// <returns></returns>
        public bool ProcessCurrent(bool forceReprocess=false)
        {
            bool processed = false;

            if (forceReprocess || !CurrentImageIsProcessed)
            {
                if (DataTableLoaded == null || DataTableLoaded.Rows.Count == 0)
                {
                    LoadPalette();
                }

                GetIndexedTable(false, forceReprocess);
                GetMatchedTable(false, forceReprocess);

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

            if (CurrentFileIndex < (FileNames.Count - 1))
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
        public DataTable GetIndexedTable(bool applyThreshold, bool forceReprocess = false)
        {
            if (forceReprocess || !CurrentImageIsProcessed)
            {
                try
                {
                    // Load image
                    CurrentImageOriginal = new Bitmap(CurrentFileName);
                    if (CurrentImageOriginal == null)
                        throw new Exception("Error reading image.");

                    // Convert to indexed image
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
                    row[PaletteGridColumns.R] = color.R;
                    row[PaletteGridColumns.G] = color.G;
                    row[PaletteGridColumns.B] = color.B;
                    row[PaletteGridColumns.A] = color.A;
                    row[PaletteGridColumns.Count] = count;
                    row[PaletteGridColumns.Percentage] = (double)(count * 100) / (double)totalPixels;

                    DataTableIndexed.Rows.Add(row);
                }

                DataTableIndexed.DefaultView.Sort = PaletteGridColumns.Count + " DESC";
            }

            DataTableIndexed.DefaultView.RowFilter = applyThreshold ? string.Format("[{0}] >= {1}", PaletteGridColumns.Percentage, Parameters.ThresholdIndexed) : null;

            return DataTableIndexed;
        }

        public DataTable GetMatchedTable(bool applyThreshold, bool forceReprocess = false)
        {
            if (forceReprocess || !CurrentImageIsProcessed)
            {
                if (DataTableIndexed == null || DataTableIndexed.Rows.Count == 0 || DataTableLoaded == null || DataTableLoaded.Rows.Count == 0)
                    throw new Exception("Need to have both the indexed and loaded colors to match by distance.");

                // Apply index threshold if necessary
                // The threshold is already applied to the default view of the DataTableIndexed
                DataTable dtIndexed = Parameters.ApplyThresholdIndexed ? DataTableIndexed.DefaultView.ToTable() : DataTableIndexed;

                HashSet<Color> palette = GetPalette();
                DataTableMatched.Rows.Clear();
                foreach (DataRow rowIndexed in dtIndexed.Rows)
                {
                    Color colorIndexed = Color.FromArgb(
                        (int)rowIndexed[PaletteGridColumns.A],
                        (int)rowIndexed[PaletteGridColumns.R],
                        (int)rowIndexed[PaletteGridColumns.G],
                        (int)rowIndexed[PaletteGridColumns.B]);

                    foreach (Color colorPalette in palette)
                    {
                        double distance = ColorDistance(colorIndexed, colorPalette);
                        if (IsWithinDistance(distance))
                        {
                            rowIndexed[PaletteGridColumns.Distance] = distance;
                            DataRow row = DataTableMatched.NewRow();
                            //row[PaletteGridColumns.A]

                            //DataTableMatched.Rows.Add(row);

                            // Each color can potentially be matched to more than one color in the palette
                            // The break below prevents that from happening
                            // Easier to implement (no need to track multiple matches per color), especially in the UI
                            // Slightly faster also
                            break;
                        }
                    }
                }


                DataTableMatched.DefaultView.RowFilter = applyThreshold ? string.Format("[{0}] >= {1}", PaletteGridColumns.Percentage, Parameters.ThresholdMatched) : null;
            }

            return DataTableMatched;
        }
    }
}