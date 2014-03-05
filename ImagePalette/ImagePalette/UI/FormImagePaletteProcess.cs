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

        public FormImagePaletteProcess(ImagePaletteParameters parameters)
        {
            InitializeComponent();
            PaletteProcessor = new ImagePaletteProcess(parameters);
        }

        private void FormImageOriginal_Load(object sender, EventArgs e)
        {
            SetBindings();
            PaletteProcessor.ProcessCurrentImage();
        }

        ImagePaletteParameters Parameters
        {
            get { return PaletteProcessor.Parameters; }
        }

        private void SetBindings()
        {
            // Set bindings between the UI and variables
            try
            {
                numericUpDownDistance.DataBindings.Add("Value", PaletteProcessor.Parameters, "Distance");
                numericUpDownThresholdIndexed.DataBindings.Add("Value", PaletteProcessor.Parameters, "ThresholdIndexed");
                numericUpDownThresholdMatched.DataBindings.Add("Value", PaletteProcessor.Parameters, "ThresholdMatched");
                paletteGridIndexed.DataGridView.DataSource = PaletteProcessor.DataTableIndexed.DefaultView;
                paletteGridLoaded.DataGridView.DataSource = PaletteProcessor.DataTableLoaded.DefaultView;
                paletteGridMatched.DataGridView.DataSource = PaletteProcessor.DataTableMatched.DefaultView;
                pictureBoxOriginal.Image = PaletteProcessor.CurrentImageOriginal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error setting bindings");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            if (pictureBoxOriginal.Image != null)
            {
                FormImage formImage = new FormImage("Original", pictureBoxOriginal.Image);
                formImage.Show();
            }
        }

        private void pictureBoxIndexed_Click(object sender, EventArgs e)
        {
            if (pictureBoxIndexed.Image != null)
            {
                FormImage formImage = new FormImage("Indexed", pictureBoxIndexed.Image);
                formImage.Show();
            }
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
