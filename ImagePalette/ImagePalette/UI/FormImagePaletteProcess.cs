﻿using System;
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

        private FormImage formImageOriginal;
        private FormImage formImageIndexed;

        public FormImagePaletteProcess(ImagePaletteParameters parameters)
        {
            InitializeComponent();
            PaletteProcessor = new ImagePaletteProcess(parameters);
        }

        private void FormImageOriginal_Load(object sender, EventArgs e)
        {
            formImageOriginal = new FormImage("Original");
            formImageIndexed = new FormImage("Indexed");

            // Had to downcast to Control b/c AllowDrop on PictureBox is overriden with
            // [BrowsableAttribute(false)], not sure why, and AllowDrop is not available in PictureBox in the UI designer
            ((Control)pictureBoxOriginal).AllowDrop = true;

            // Register for events when properties are modified
            PaletteProcessor.Parameters.PropertyChanged += new PropertyChangedEventHandler(imagePaletteParameters_PropertyChanged);
            PaletteProcessor.ImageChangedEvent += new ImageChangedHandler(paletteProcessor_OnImageChanged);

            SetBindings();
            UpdateUIPreviousNextButtons();
            ProcessImage();
        }

        private void SetBindings()
        {
            // Set bindings between the UI and variables
            try
            {
                numericUpDownCoverage.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                numericUpDownCoverage.DataBindings.Add("Value", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.Coverage).Name);

                numericUpDownDistance.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                numericUpDownDistance.DataBindings.Add("Value", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.Distance).Name);

                numericUpDownThresholdIndexed.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                numericUpDownThresholdIndexed.DataBindings.Add("Value", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.ThresholdIndexed).Name);

                numericUpDownThresholdMatched.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                numericUpDownThresholdMatched.DataBindings.Add("Value", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.ThresholdMatched).Name);

                checkBoxApplyThresholdDistance.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                checkBoxApplyThresholdDistance.DataBindings.Add("Checked", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.ApplyThresholdDistance).Name);

                checkBoxApplyThresholdIndexed.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                checkBoxApplyThresholdIndexed.DataBindings.Add("Checked", PaletteProcessor.Parameters, 
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.ApplyThresholdIndexed).Name);

                checkBoxApplyThresholdMatched.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                checkBoxApplyThresholdMatched.DataBindings.Add("Checked", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.ApplyThresholdMatched).Name);

                checkBoxExploreMode.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                checkBoxExploreMode.DataBindings.Add("Checked", PaletteProcessor.Parameters,
                    Util.GetMemberInfo((ImagePaletteParameters s) => s.ExploreMode).Name);

                // DataSource is the DataView instead of DataTable to account for filtering and sorting
                paletteGridIndexed.DataGridView.DataSource = PaletteProcessor.DataTableIndexed.DefaultView;
                paletteGridLoaded.DataGridView.DataSource = PaletteProcessor.DataTableLoaded.DefaultView;
                paletteGridMatched.DataGridView.DataSource = PaletteProcessor.DataTableMatched.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error setting bindings");
            }
        }

        protected void imagePaletteParameters_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.Assert(object.ReferenceEquals(sender, PaletteProcessor.Parameters));

            if (e.PropertyName.Equals(Util.GetMemberInfo((ImagePaletteParameters s) => s.FileNames).Name))
            {
                UpdateUIPreviousNextButtons();
            }

        }

        private void ProcessImage()
        {
            try
            {
                PaletteProcessor.ProcessCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error processing image");
            }
        }

        private void paletteProcessor_OnImageChanged(object sender)
        {
            System.Diagnostics.Debug.Assert(object.ReferenceEquals(sender, PaletteProcessor));

            pictureBoxOriginal.Image = PaletteProcessor.CurrentImageOriginal;
            pictureBoxIndexed.Image = PaletteProcessor.CurrentImageIndexed;

            formImageOriginal.Image = PaletteProcessor.CurrentImageOriginal;
            formImageIndexed.Image = PaletteProcessor.CurrentImageIndexed;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            PaletteProcessor.ProcessAll();
            PaletteProcessor.Results.Save();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            if (formImageOriginal == null || formImageOriginal.IsDisposed)
            {
                formImageOriginal = new FormImage("Original");
                formImageOriginal.Image = PaletteProcessor.CurrentImageOriginal;
            }

            if (!formImageOriginal.Visible)
                formImageOriginal.Show();
            else
                formImageOriginal.BringToFront();
        }

        private void pictureBoxIndexed_Click(object sender, EventArgs e)
        {
            if (formImageIndexed == null || formImageIndexed.IsDisposed)
            {
                formImageIndexed = new FormImage("Indexed");
                formImageIndexed.Image = PaletteProcessor.CurrentImageIndexed;
            }

            if (!formImageIndexed.Visible)
                formImageIndexed.Show();
            else
                formImageIndexed.BringToFront();
        }

        private void FormImagePaletteProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formImageOriginal!= null && formImageOriginal.Visible)
                formImageOriginal.Close();

            if (formImageIndexed != null && formImageIndexed.Visible)
                formImageIndexed.Close();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            PaletteProcessor.ProcessPrevious();
            UpdateUIPreviousNextButtons();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            PaletteProcessor.ProcessNext();
            UpdateUIPreviousNextButtons();
        }

        private void UpdateUIPreviousNextButtons()
        {
            buttonNext.Enabled = PaletteProcessor.CurrentFileIndex < (PaletteProcessor.FileNamesExpanded.Count - 1);
            buttonPrevious.Enabled = PaletteProcessor.CurrentFileIndex > 0;
        }

        private void pictureBoxOriginal_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureBoxOriginal_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                PaletteProcessor.Parameters.FileNames = new List<string>(files);
            }
        }
    }
}
