using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePalette
{
    public partial class FormImagePaletteProcess : Form
    {
        public ImagePaletteProcess PaletteProcessor { get; private set; }

        Hashtable indexedFromImage;
        DataTable dtIndexedFromImage;

        public FormImagePaletteProcess(ImagePaletteParameters parameters)
        {
            InitializeComponent();
            PaletteProcessor = new ImagePaletteProcess(parameters);
        }

        private void FormImageOriginal_Load(object sender, EventArgs e)
        {
            SetBindings();
            LoadPalette();
            Process();
        }

        ImagePaletteParameters Parameters
        {
            get { return PaletteProcessor.Parameters; }
            //set
            //{
            //    SetBindings();
            //    pictureBoxOriginal.Image = null;
            //    pictureBoxIndexed.Image = null;
            //}
        }

        private void SetBindings()
        {
            // Set bindings between the UI and variables
            try
            {
                numericUpDownDistance.DataBindings.Add("Value", Parameters, "Distance");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error setting bindings");
            }
        }

        private void LoadPalette()
        {
            if (!string.IsNullOrWhiteSpace(Parameters.FileNameReference))
            {
                DataTable dtPalette = new DataTable("Loaded as Reference");
                dtPalette.Columns.AddRange(new DataColumn[] {
                    new DataColumn(PaletteGridColumns.Color, typeof(string)),
                    new DataColumn(PaletteGridColumns.R, typeof(int)),
                    new DataColumn(PaletteGridColumns.G, typeof(int)),
                    new DataColumn(PaletteGridColumns.B, typeof(int)),
                    new DataColumn(PaletteGridColumns.A, typeof(int))
                });

                HashSet<Color> palette = new PaletteReader(Parameters.FileNameReference).GetPalette();
                if (palette != null && palette.Count > 0)
                {
                    foreach (Color color in palette)
                    {
                        DataRow row = dtPalette.NewRow();
                        row["R"] = color.R;
                        row["G"] = color.G;
                        row["B"] = color.B;
                        row["A"] = color.A;

                        dtPalette.Rows.Add(row);
                    }
                }

                paletteGridLoaded.DataTable = dtPalette;  
            }
        }

        private void Process()
        {
            LoadImage(Parameters.FileName);
            ConvertToIndexedImage();
            IndexColorsFromImage();

            UpdateUI();

            MatchColorsByDistance();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadImage(string fileName)
        {
            pictureBoxOriginal.Load(fileName);
        }

        private void ConvertToIndexedImage()
        {
            if (pictureBoxOriginal.Image == null)
                return;

            MemoryStream bitStream = new MemoryStream();
            pictureBoxOriginal.Image.Save(bitStream, ImageFormat.Gif);
            pictureBoxIndexed.Image = new Bitmap(bitStream);
        }

        private void IndexColorsFromImage()
        {
            if (pictureBoxIndexed.Image == null)
                return;

            Bitmap image = (Bitmap)pictureBoxIndexed.Image;
            indexedFromImage = new Hashtable();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    if (indexedFromImage[color] == null)
                        indexedFromImage[color] = 1;
                    else
                        indexedFromImage[color] = (int)indexedFromImage[color] + 1;
                }
            }
        }

        private void MatchColorsByDistance()
        {
            if (paletteGridIndexed.DataTable == null || paletteGridLoaded.DataTable == null)
                throw new Exception("Need to have both the indexed and loaded colors to match by distance.");

            ImagePaletteProcess process = new ImagePaletteProcess(Parameters);
            foreach (Color cIndexed in paletteGridIndexed.GetAllColors())
            {
                foreach (Color cLoaded in paletteGridLoaded.GetAllColors())
                {
                    //if (process.IsWithinDistance)
                    //{
                    //}
                }
            }
        }

        private void UpdateUI()
        {
            dtIndexedFromImage = new DataTable("Indexed From Image");
            dtIndexedFromImage.Columns.AddRange(new DataColumn[] {
                new DataColumn(PaletteGridColumns.Color, typeof(string)),
                new DataColumn(PaletteGridColumns.R, typeof(int)),
                new DataColumn(PaletteGridColumns.G, typeof(int)),
                new DataColumn(PaletteGridColumns.B, typeof(int)),
                new DataColumn(PaletteGridColumns.A, typeof(int)),
                new DataColumn(PaletteGridColumns.Count, typeof(int))
            });

            foreach (DictionaryEntry entry in indexedFromImage)
            {
                Color color = (Color)entry.Key;
                int count = (int)entry.Value;

                DataRow row = dtIndexedFromImage.NewRow();
                row[PaletteGridColumns.R] = color.R;
                row[PaletteGridColumns.G] = color.G;
                row[PaletteGridColumns.B] = color.B;
                row[PaletteGridColumns.A] = color.A;
                row[PaletteGridColumns.Count] = count;

                dtIndexedFromImage.Rows.Add(row);
            }

            dtIndexedFromImage.DefaultView.Sort = PaletteGridColumns.Count + " DESC";
            paletteGridIndexed.DataTable = dtIndexedFromImage.DefaultView.ToTable(dtIndexedFromImage.TableName);
        }


        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            FormImage formImage = new FormImage("Original", pictureBoxOriginal.Image);
            formImage.Show();
        }

        private void pictureBoxIndexed_Click(object sender, EventArgs e)
        {
            FormImage formImage = new FormImage("Indexed", pictureBoxIndexed.Image);
            formImage.Show();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void panelSpectrum_Paint(object sender, PaintEventArgs e)
        {
            // Create the color spectrum.
            // From http://stackoverflow.com/questions/2288498/how-do-i-get-a-rainbow-color-gradient-in-c
            
            int numColors = 100;
            double colorIncrease = (double)1/(double)numColors;
            double posIncrease = (double)e.ClipRectangle.Width/ (double)numColors;
            Size size = new Size(Convert.ToInt16(Math.Ceiling(posIncrease)), e.ClipRectangle.Height);
            Point location = new Point(0, 0);
            for (double i = 0, x = 0; i < 1; i += colorIncrease, x += posIncrease)
            {
                Color color = ImagePaletteProcess.HSL2RGB(i, 0.5, 0.5);
                SolidBrush brush = new SolidBrush(color);

                location.X = (int)x;
                Rectangle rect = new Rectangle(location, size);
                e.Graphics.FillRectangle(brush, rect);
            }
        }
    }
}
