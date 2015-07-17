namespace ImagePalette
{
    partial class FormImagePaletteProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelImageOriginal = new System.Windows.Forms.Label();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.labelImageIndexed = new System.Windows.Forms.Label();
            this.pictureBoxIndexed = new System.Windows.Forms.PictureBox();
            this.labelIndexedFromImage = new System.Windows.Forms.Label();
            this.labelLoaded = new System.Windows.Forms.Label();
            this.labelMatchedByDistance = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBoxApplyThresholdDistance = new System.Windows.Forms.CheckBox();
            this.checkBoxApplyThresholdIndexed = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBoxApplyThresholdMatched = new System.Windows.Forms.CheckBox();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelThresholdIndexed = new System.Windows.Forms.Label();
            this.numericUpDownThresholdIndexed = new System.Windows.Forms.NumericUpDown();
            this.labelThresholdIndexedPercent = new System.Windows.Forms.Label();
            this.labelThresholdMatched = new System.Windows.Forms.Label();
            this.numericUpDownThresholdMatched = new System.Windows.Forms.NumericUpDown();
            this.labelThresholdMatchedPercent = new System.Windows.Forms.Label();
            this.checkBoxExploreMode = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCoverage = new System.Windows.Forms.Label();
            this.numericUpDownCoverage = new System.Windows.Forms.NumericUpDown();
            this.labelCoveragePercentage = new System.Windows.Forms.Label();
            this.spectrumPanel = new ImagePalette.UI.SpectrumPanel();
            this.paletteGridIndexed = new ImagePalette.PaletteGrid();
            this.paletteGridLoaded = new ImagePalette.PaletteGrid();
            this.paletteGridMatched = new ImagePalette.PaletteGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIndexed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIndexed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdMatched)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoverage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelImageOriginal
            // 
            this.labelImageOriginal.AutoSize = true;
            this.labelImageOriginal.Location = new System.Drawing.Point(13, 13);
            this.labelImageOriginal.Name = "labelImageOriginal";
            this.labelImageOriginal.Size = new System.Drawing.Size(74, 13);
            this.labelImageOriginal.TabIndex = 0;
            this.labelImageOriginal.Text = "Original Image";
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Location = new System.Drawing.Point(13, 30);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(176, 145);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            this.pictureBoxOriginal.Click += new System.EventHandler(this.pictureBoxOriginal_Click);
            this.pictureBoxOriginal.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBoxOriginal_DragDrop);
            this.pictureBoxOriginal.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureBoxOriginal_DragOver);
            // 
            // labelImageIndexed
            // 
            this.labelImageIndexed.AutoSize = true;
            this.labelImageIndexed.Location = new System.Drawing.Point(13, 186);
            this.labelImageIndexed.Name = "labelImageIndexed";
            this.labelImageIndexed.Size = new System.Drawing.Size(104, 13);
            this.labelImageIndexed.TabIndex = 1;
            this.labelImageIndexed.Text = "Indexed Color Image";
            // 
            // pictureBoxIndexed
            // 
            this.pictureBoxIndexed.Location = new System.Drawing.Point(13, 203);
            this.pictureBoxIndexed.Name = "pictureBoxIndexed";
            this.pictureBoxIndexed.Size = new System.Drawing.Size(176, 142);
            this.pictureBoxIndexed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIndexed.TabIndex = 3;
            this.pictureBoxIndexed.TabStop = false;
            this.pictureBoxIndexed.Click += new System.EventHandler(this.pictureBoxIndexed_Click);
            // 
            // labelIndexedFromImage
            // 
            this.labelIndexedFromImage.AutoSize = true;
            this.labelIndexedFromImage.Location = new System.Drawing.Point(3, 0);
            this.labelIndexedFromImage.Name = "labelIndexedFromImage";
            this.labelIndexedFromImage.Size = new System.Drawing.Size(99, 13);
            this.labelIndexedFromImage.TabIndex = 0;
            this.labelIndexedFromImage.Text = "Indexed from image";
            // 
            // labelLoaded
            // 
            this.labelLoaded.AutoSize = true;
            this.labelLoaded.Location = new System.Drawing.Point(3, 0);
            this.labelLoaded.Name = "labelLoaded";
            this.labelLoaded.Size = new System.Drawing.Size(43, 13);
            this.labelLoaded.TabIndex = 0;
            this.labelLoaded.Text = "Loaded";
            // 
            // labelMatchedByDistance
            // 
            this.labelMatchedByDistance.AutoSize = true;
            this.labelMatchedByDistance.Location = new System.Drawing.Point(3, 0);
            this.labelMatchedByDistance.Name = "labelMatchedByDistance";
            this.labelMatchedByDistance.Size = new System.Drawing.Size(108, 13);
            this.labelMatchedByDistance.TabIndex = 0;
            this.labelMatchedByDistance.Text = "Matched by Distance";
            // 
            // labelDistance
            // 
            this.labelDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(10, 360);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(99, 13);
            this.labelDistance.TabIndex = 2;
            this.labelDistance.Text = "Max Color Distance";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDistance.Location = new System.Drawing.Point(113, 358);
            this.numericUpDownDistance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownDistance.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(1110, 438);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(205, 13);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxApplyThresholdDistance);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxApplyThresholdIndexed);
            this.splitContainer1.Panel1.Controls.Add(this.paletteGridIndexed);
            this.splitContainer1.Panel1.Controls.Add(this.labelIndexedFromImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(980, 387);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 10;
            // 
            // checkBoxApplyThresholdDistance
            // 
            this.checkBoxApplyThresholdDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxApplyThresholdDistance.AutoSize = true;
            this.checkBoxApplyThresholdDistance.Location = new System.Drawing.Point(274, -1);
            this.checkBoxApplyThresholdDistance.Name = "checkBoxApplyThresholdDistance";
            this.checkBoxApplyThresholdDistance.Size = new System.Drawing.Size(118, 17);
            this.checkBoxApplyThresholdDistance.TabIndex = 3;
            this.checkBoxApplyThresholdDistance.Text = "Distance Threshold";
            this.checkBoxApplyThresholdDistance.UseVisualStyleBackColor = true;
            // 
            // checkBoxApplyThresholdIndexed
            // 
            this.checkBoxApplyThresholdIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxApplyThresholdIndexed.AutoSize = true;
            this.checkBoxApplyThresholdIndexed.Location = new System.Drawing.Point(164, -1);
            this.checkBoxApplyThresholdIndexed.Name = "checkBoxApplyThresholdIndexed";
            this.checkBoxApplyThresholdIndexed.Size = new System.Drawing.Size(104, 17);
            this.checkBoxApplyThresholdIndexed.TabIndex = 2;
            this.checkBoxApplyThresholdIndexed.Text = "Count Threshold";
            this.checkBoxApplyThresholdIndexed.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.paletteGridLoaded);
            this.splitContainer2.Panel1.Controls.Add(this.labelLoaded);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.checkBoxApplyThresholdMatched);
            this.splitContainer2.Panel2.Controls.Add(this.labelMatchedByDistance);
            this.splitContainer2.Panel2.Controls.Add(this.paletteGridMatched);
            this.splitContainer2.Size = new System.Drawing.Size(581, 387);
            this.splitContainer2.SplitterDistance = 275;
            this.splitContainer2.TabIndex = 14;
            // 
            // checkBoxApplyThresholdMatched
            // 
            this.checkBoxApplyThresholdMatched.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxApplyThresholdMatched.AutoSize = true;
            this.checkBoxApplyThresholdMatched.Location = new System.Drawing.Point(193, -1);
            this.checkBoxApplyThresholdMatched.Name = "checkBoxApplyThresholdMatched";
            this.checkBoxApplyThresholdMatched.Size = new System.Drawing.Size(106, 17);
            this.checkBoxApplyThresholdMatched.TabIndex = 2;
            this.checkBoxApplyThresholdMatched.Text = "Match Threshold";
            this.checkBoxApplyThresholdMatched.UseVisualStyleBackColor = true;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.Location = new System.Drawing.Point(1029, 409);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 11;
            this.buttonPrevious.Text = "< Prev";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(1110, 409);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 12;
            this.buttonNext.Text = "Next >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelThresholdIndexed
            // 
            this.labelThresholdIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelThresholdIndexed.AutoSize = true;
            this.labelThresholdIndexed.Location = new System.Drawing.Point(10, 387);
            this.labelThresholdIndexed.Name = "labelThresholdIndexed";
            this.labelThresholdIndexed.Size = new System.Drawing.Size(95, 13);
            this.labelThresholdIndexed.TabIndex = 4;
            this.labelThresholdIndexed.Text = "Threshold Indexed";
            // 
            // numericUpDownThresholdIndexed
            // 
            this.numericUpDownThresholdIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownThresholdIndexed.DecimalPlaces = 2;
            this.numericUpDownThresholdIndexed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownThresholdIndexed.Location = new System.Drawing.Point(113, 385);
            this.numericUpDownThresholdIndexed.Name = "numericUpDownThresholdIndexed";
            this.numericUpDownThresholdIndexed.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownThresholdIndexed.TabIndex = 5;
            // 
            // labelThresholdIndexedPercent
            // 
            this.labelThresholdIndexedPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelThresholdIndexedPercent.AutoSize = true;
            this.labelThresholdIndexedPercent.Location = new System.Drawing.Point(180, 387);
            this.labelThresholdIndexedPercent.Name = "labelThresholdIndexedPercent";
            this.labelThresholdIndexedPercent.Size = new System.Drawing.Size(15, 13);
            this.labelThresholdIndexedPercent.TabIndex = 6;
            this.labelThresholdIndexedPercent.Text = "%";
            // 
            // labelThresholdMatched
            // 
            this.labelThresholdMatched.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelThresholdMatched.AutoSize = true;
            this.labelThresholdMatched.Location = new System.Drawing.Point(10, 414);
            this.labelThresholdMatched.Name = "labelThresholdMatched";
            this.labelThresholdMatched.Size = new System.Drawing.Size(99, 13);
            this.labelThresholdMatched.TabIndex = 7;
            this.labelThresholdMatched.Text = "Threshold Matched";
            // 
            // numericUpDownThresholdMatched
            // 
            this.numericUpDownThresholdMatched.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownThresholdMatched.Location = new System.Drawing.Point(113, 412);
            this.numericUpDownThresholdMatched.Name = "numericUpDownThresholdMatched";
            this.numericUpDownThresholdMatched.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownThresholdMatched.TabIndex = 8;
            // 
            // labelThresholdMatchedPercent
            // 
            this.labelThresholdMatchedPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelThresholdMatchedPercent.AutoSize = true;
            this.labelThresholdMatchedPercent.Location = new System.Drawing.Point(180, 414);
            this.labelThresholdMatchedPercent.Name = "labelThresholdMatchedPercent";
            this.labelThresholdMatchedPercent.Size = new System.Drawing.Size(15, 13);
            this.labelThresholdMatchedPercent.TabIndex = 9;
            this.labelThresholdMatchedPercent.Text = "%";
            // 
            // checkBoxExploreMode
            // 
            this.checkBoxExploreMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxExploreMode.AutoSize = true;
            this.checkBoxExploreMode.Location = new System.Drawing.Point(787, 410);
            this.checkBoxExploreMode.Name = "checkBoxExploreMode";
            this.checkBoxExploreMode.Size = new System.Drawing.Size(91, 17);
            this.checkBoxExploreMode.TabIndex = 15;
            this.checkBoxExploreMode.Text = "Explore Mode";
            this.checkBoxExploreMode.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(1029, 438);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCoverage
            // 
            this.labelCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCoverage.AutoSize = true;
            this.labelCoverage.Location = new System.Drawing.Point(10, 441);
            this.labelCoverage.Name = "labelCoverage";
            this.labelCoverage.Size = new System.Drawing.Size(53, 13);
            this.labelCoverage.TabIndex = 17;
            this.labelCoverage.Text = "Coverage";
            // 
            // numericUpDownCoverage
            // 
            this.numericUpDownCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownCoverage.Location = new System.Drawing.Point(113, 439);
            this.numericUpDownCoverage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCoverage.Name = "numericUpDownCoverage";
            this.numericUpDownCoverage.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownCoverage.TabIndex = 18;
            this.numericUpDownCoverage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelCoveragePercentage
            // 
            this.labelCoveragePercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCoveragePercentage.AutoSize = true;
            this.labelCoveragePercentage.Location = new System.Drawing.Point(180, 441);
            this.labelCoveragePercentage.Name = "labelCoveragePercentage";
            this.labelCoveragePercentage.Size = new System.Drawing.Size(15, 13);
            this.labelCoveragePercentage.TabIndex = 19;
            this.labelCoveragePercentage.Text = "%";
            // 
            // spectrumPanel
            // 
            this.spectrumPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spectrumPanel.Location = new System.Drawing.Point(228, 406);
            this.spectrumPanel.Name = "spectrumPanel";
            this.spectrumPanel.Size = new System.Drawing.Size(553, 55);
            this.spectrumPanel.TabIndex = 20;
            // 
            // paletteGridIndexed
            // 
            this.paletteGridIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridIndexed.Location = new System.Drawing.Point(3, 16);
            this.paletteGridIndexed.Name = "paletteGridIndexed";
            this.paletteGridIndexed.ShowRgbaColumns = false;
            this.paletteGridIndexed.Size = new System.Drawing.Size(389, 368);
            this.paletteGridIndexed.TabIndex = 1;
            // 
            // paletteGridLoaded
            // 
            this.paletteGridLoaded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridLoaded.Location = new System.Drawing.Point(3, 17);
            this.paletteGridLoaded.Name = "paletteGridLoaded";
            this.paletteGridLoaded.ShowRgbaColumns = false;
            this.paletteGridLoaded.Size = new System.Drawing.Size(269, 367);
            this.paletteGridLoaded.TabIndex = 1;
            // 
            // paletteGridMatched
            // 
            this.paletteGridMatched.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridMatched.Location = new System.Drawing.Point(3, 17);
            this.paletteGridMatched.Name = "paletteGridMatched";
            this.paletteGridMatched.ShowRgbaColumns = false;
            this.paletteGridMatched.Size = new System.Drawing.Size(296, 367);
            this.paletteGridMatched.TabIndex = 1;
            // 
            // FormImagePaletteProcess
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1197, 469);
            this.Controls.Add(this.spectrumPanel);
            this.Controls.Add(this.labelCoveragePercentage);
            this.Controls.Add(this.numericUpDownCoverage);
            this.Controls.Add(this.labelCoverage);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxExploreMode);
            this.Controls.Add(this.labelThresholdMatchedPercent);
            this.Controls.Add(this.numericUpDownThresholdMatched);
            this.Controls.Add(this.labelThresholdMatched);
            this.Controls.Add(this.labelThresholdIndexedPercent);
            this.Controls.Add(this.numericUpDownThresholdIndexed);
            this.Controls.Add(this.labelThresholdIndexed);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownDistance);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.pictureBoxIndexed);
            this.Controls.Add(this.labelImageIndexed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.labelImageOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormImagePaletteProcess";
            this.ShowInTaskbar = false;
            this.Text = "Image Palette";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormImagePaletteProcess_FormClosing);
            this.Load += new System.EventHandler(this.FormImageOriginal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIndexed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIndexed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdMatched)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoverage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelImageOriginal;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.Label labelImageIndexed;
        private System.Windows.Forms.PictureBox pictureBoxIndexed;
        private System.Windows.Forms.Label labelIndexedFromImage;
        private System.Windows.Forms.Label labelLoaded;
        private System.Windows.Forms.Label labelMatchedByDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private PaletteGrid paletteGridIndexed;
        private PaletteGrid paletteGridLoaded;
        private PaletteGrid paletteGridMatched;
        private System.Windows.Forms.Label labelThresholdIndexed;
        private System.Windows.Forms.NumericUpDown numericUpDownThresholdIndexed;
        private System.Windows.Forms.Label labelThresholdIndexedPercent;
        private System.Windows.Forms.Label labelThresholdMatched;
        private System.Windows.Forms.NumericUpDown numericUpDownThresholdMatched;
        private System.Windows.Forms.Label labelThresholdMatchedPercent;
        private System.Windows.Forms.CheckBox checkBoxApplyThresholdIndexed;
        private System.Windows.Forms.CheckBox checkBoxApplyThresholdMatched;
        private System.Windows.Forms.CheckBox checkBoxApplyThresholdDistance;
        private System.Windows.Forms.CheckBox checkBoxExploreMode;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCoverage;
        private System.Windows.Forms.NumericUpDown numericUpDownCoverage;
        private System.Windows.Forms.Label labelCoveragePercentage;
        private UI.SpectrumPanel spectrumPanel;
    }
}