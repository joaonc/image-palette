using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePalette
{
    public partial class FormImagePalette : Form
    {
        ImagePaletteParameters parameters;

        public FormImagePalette()
        {
            InitializeComponent();
        }

        private void FormImagePalette_Load(object sender, EventArgs e)
        {
            // Set defaults
            parameters = new ImagePaletteParameters();
            parameters.FileNames = new List<string>(new string[] { @"C:\Users\Joao\Documents\Visual Studio 2012\Projects\ImagePalette\Resources\CCMG707.jpg" });
            parameters.FileNameReference = @"C:\Users\Joao\Documents\Visual Studio 2012\Projects\ImagePalette\Resources\colors-blog-cr.csv";
            parameters.FileNameOutput = @"C:\Users\Joao\Documents\Visual Studio 2012\Projects\ImagePalette\Resources\output.xml";
            parameters.Coverage = 100;
            parameters.Distance = 1000;
            parameters.ThresholdIndexed = 8;
            parameters.ThresholdMatched = 10;
            parameters.ExploreMode = true;

            // Set UI bindings
            try
            {
                textBoxFileName.DataBindings.Add("Text", parameters, "FileNames");
                textBoxFileNameReference.DataBindings.Add("Text", parameters, "FileNameReference");
                numericUpDownCoverage.DataBindings.Add("Value", parameters, "Coverage");
                numericUpDownDistance.DataBindings.Add("Value", parameters, "Distance");
                numericUpDownThresholdIndexed.DataBindings.Add("Value", parameters, "ThresholdIndexed");
                numericUpDownThresholdMatched.DataBindings.Add("Value", parameters, "ThresholdMatched");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error setting bindings");
            }

            // Update remaining UI
            groupBoxReference.Enabled = !string.IsNullOrWhiteSpace(parameters.FileNameReference);
        }

        private void textBoxFileName_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBoxFileName_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                textBoxFileName.Text = files[0];
            }
        }

        private void textBoxFileNameReference_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBoxFileNameReference_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                textBoxFileNameReference.Text = files[0];
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            FormImagePaletteProcess formImage = new FormImagePaletteProcess(parameters);
            formImage.ShowDialog();
        }

        private void checkBoxIncludeReference_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxReference.Enabled = checkBoxIncludeReference.Checked;
        }
    }
}
