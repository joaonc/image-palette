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
            this.labelColorDistance = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panelSpectrum = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelThresholdApplied = new System.Windows.Forms.Label();
            this.paletteGridIndexed = new ImagePalette.PaletteGrid();
            this.paletteGridLoaded = new ImagePalette.PaletteGrid();
            this.paletteGridDistance = new ImagePalette.PaletteGrid();
            this.paletteGridThreshold = new ImagePalette.PaletteGrid();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            // 
            // labelImageIndexed
            // 
            this.labelImageIndexed.AutoSize = true;
            this.labelImageIndexed.Location = new System.Drawing.Point(13, 205);
            this.labelImageIndexed.Name = "labelImageIndexed";
            this.labelImageIndexed.Size = new System.Drawing.Size(104, 13);
            this.labelImageIndexed.TabIndex = 2;
            this.labelImageIndexed.Text = "Indexed Color Image";
            // 
            // pictureBoxIndexed
            // 
            this.pictureBoxIndexed.Location = new System.Drawing.Point(13, 222);
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
            this.labelIndexedFromImage.TabIndex = 4;
            this.labelIndexedFromImage.Text = "Indexed from image";
            // 
            // labelLoaded
            // 
            this.labelLoaded.AutoSize = true;
            this.labelLoaded.Location = new System.Drawing.Point(3, 0);
            this.labelLoaded.Name = "labelLoaded";
            this.labelLoaded.Size = new System.Drawing.Size(43, 13);
            this.labelLoaded.TabIndex = 6;
            this.labelLoaded.Text = "Loaded";
            // 
            // labelMatchedByDistance
            // 
            this.labelMatchedByDistance.AutoSize = true;
            this.labelMatchedByDistance.Location = new System.Drawing.Point(3, 0);
            this.labelMatchedByDistance.Name = "labelMatchedByDistance";
            this.labelMatchedByDistance.Size = new System.Drawing.Size(108, 13);
            this.labelMatchedByDistance.TabIndex = 8;
            this.labelMatchedByDistance.Text = "Matched by Distance";
            // 
            // labelColorDistance
            // 
            this.labelColorDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelColorDistance.AutoSize = true;
            this.labelColorDistance.Location = new System.Drawing.Point(13, 394);
            this.labelColorDistance.Name = "labelColorDistance";
            this.labelColorDistance.Size = new System.Drawing.Size(76, 13);
            this.labelColorDistance.TabIndex = 10;
            this.labelColorDistance.Text = "Color Distance";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDistance.Location = new System.Drawing.Point(95, 392);
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownDistance.TabIndex = 11;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(973, 398);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(228, 13);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.paletteGridIndexed);
            this.splitContainer1.Panel1.Controls.Add(this.labelIndexedFromImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(820, 351);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 13;
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
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(568, 351);
            this.splitContainer2.SplitterDistance = 178;
            this.splitContainer2.TabIndex = 14;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.Location = new System.Drawing.Point(776, 398);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 14;
            this.buttonPrevious.Text = "< Prev";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(857, 398);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = "Next >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // panelSpectrum
            // 
            this.panelSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSpectrum.Location = new System.Drawing.Point(228, 382);
            this.panelSpectrum.Name = "panelSpectrum";
            this.panelSpectrum.Size = new System.Drawing.Size(416, 36);
            this.panelSpectrum.TabIndex = 16;
            this.panelSpectrum.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSpectrum_Paint);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.paletteGridDistance);
            this.splitContainer3.Panel1.Controls.Add(this.labelMatchedByDistance);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.paletteGridThreshold);
            this.splitContainer3.Panel2.Controls.Add(this.labelThresholdApplied);
            this.splitContainer3.Size = new System.Drawing.Size(386, 351);
            this.splitContainer3.SplitterDistance = 206;
            this.splitContainer3.TabIndex = 10;
            // 
            // labelThresholdApplied
            // 
            this.labelThresholdApplied.AutoSize = true;
            this.labelThresholdApplied.Location = new System.Drawing.Point(3, 0);
            this.labelThresholdApplied.Name = "labelThresholdApplied";
            this.labelThresholdApplied.Size = new System.Drawing.Size(92, 13);
            this.labelThresholdApplied.TabIndex = 0;
            this.labelThresholdApplied.Text = "Threshold Applied";
            // 
            // paletteGridIndexed
            // 
            this.paletteGridIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridIndexed.DataTable = null;
            this.paletteGridIndexed.Location = new System.Drawing.Point(3, 16);
            this.paletteGridIndexed.Name = "paletteGridIndexed";
            this.paletteGridIndexed.Size = new System.Drawing.Size(242, 332);
            this.paletteGridIndexed.TabIndex = 7;
            // 
            // paletteGridLoaded
            // 
            this.paletteGridLoaded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridLoaded.DataTable = null;
            this.paletteGridLoaded.Location = new System.Drawing.Point(3, 17);
            this.paletteGridLoaded.Name = "paletteGridLoaded";
            this.paletteGridLoaded.Size = new System.Drawing.Size(172, 331);
            this.paletteGridLoaded.TabIndex = 7;
            // 
            // paletteGridDistance
            // 
            this.paletteGridDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridDistance.DataTable = null;
            this.paletteGridDistance.Location = new System.Drawing.Point(3, 17);
            this.paletteGridDistance.Name = "paletteGridDistance";
            this.paletteGridDistance.Size = new System.Drawing.Size(200, 331);
            this.paletteGridDistance.TabIndex = 9;
            // 
            // paletteGridThreshold
            // 
            this.paletteGridThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteGridThreshold.DataTable = null;
            this.paletteGridThreshold.Location = new System.Drawing.Point(3, 17);
            this.paletteGridThreshold.Name = "paletteGridThreshold";
            this.paletteGridThreshold.Size = new System.Drawing.Size(170, 331);
            this.paletteGridThreshold.TabIndex = 1;
            // 
            // FormImagePaletteProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 433);
            this.Controls.Add(this.panelSpectrum);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownDistance);
            this.Controls.Add(this.labelColorDistance);
            this.Controls.Add(this.pictureBoxIndexed);
            this.Controls.Add(this.labelImageIndexed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.labelImageOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormImagePaletteProcess";
            this.ShowInTaskbar = false;
            this.Text = "Image Palette";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelColorDistance;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panelSpectrum;
        private PaletteGrid paletteGridIndexed;
        private PaletteGrid paletteGridLoaded;
        private PaletteGrid paletteGridDistance;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private PaletteGrid paletteGridThreshold;
        private System.Windows.Forms.Label labelThresholdApplied;
    }
}