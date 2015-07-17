namespace ImagePalette
{
    partial class FormImagePalette
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
            this.labelFileOrDirectory = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelReferencePaletteFile = new System.Windows.Forms.Label();
            this.textBoxFileNameReference = new System.Windows.Forms.TextBox();
            this.checkBoxIncludeReference = new System.Windows.Forms.CheckBox();
            this.groupBoxReference = new System.Windows.Forms.GroupBox();
            this.labelThresholdIndexedPercent = new System.Windows.Forms.Label();
            this.numericUpDownThresholdIndexed = new System.Windows.Forms.NumericUpDown();
            this.labelThresholdIndexed = new System.Windows.Forms.Label();
            this.labelThresholdMatchedPercent = new System.Windows.Forms.Label();
            this.numericUpDownThresholdMatched = new System.Windows.Forms.NumericUpDown();
            this.labelThresholdMatched = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelCoverage = new System.Windows.Forms.Label();
            this.numericUpDownCoverage = new System.Windows.Forms.NumericUpDown();
            this.labelCoveragePercentage = new System.Windows.Forms.Label();
            this.groupBoxReference.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIndexed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdMatched)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoverage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFileOrDirectory
            // 
            this.labelFileOrDirectory.AutoSize = true;
            this.labelFileOrDirectory.Location = new System.Drawing.Point(13, 13);
            this.labelFileOrDirectory.Name = "labelFileOrDirectory";
            this.labelFileOrDirectory.Size = new System.Drawing.Size(80, 13);
            this.labelFileOrDirectory.TabIndex = 0;
            this.labelFileOrDirectory.Text = "File or Directory";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.AllowDrop = true;
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(13, 30);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(514, 20);
            this.textBoxFileName.TabIndex = 1;
            this.textBoxFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileName_DragDrop);
            this.textBoxFileName.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxFileName_DragOver);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Location = new System.Drawing.Point(371, 315);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 7;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(452, 315);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelReferencePaletteFile
            // 
            this.labelReferencePaletteFile.AutoSize = true;
            this.labelReferencePaletteFile.Location = new System.Drawing.Point(6, 28);
            this.labelReferencePaletteFile.Name = "labelReferencePaletteFile";
            this.labelReferencePaletteFile.Size = new System.Drawing.Size(76, 13);
            this.labelReferencePaletteFile.TabIndex = 0;
            this.labelReferencePaletteFile.Text = "Reference File";
            // 
            // textBoxFileNameReference
            // 
            this.textBoxFileNameReference.AllowDrop = true;
            this.textBoxFileNameReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileNameReference.Location = new System.Drawing.Point(6, 44);
            this.textBoxFileNameReference.Name = "textBoxFileNameReference";
            this.textBoxFileNameReference.Size = new System.Drawing.Size(502, 20);
            this.textBoxFileNameReference.TabIndex = 1;
            this.textBoxFileNameReference.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileNameReference_DragDrop);
            this.textBoxFileNameReference.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxFileNameReference_DragOver);
            // 
            // checkBoxIncludeReference
            // 
            this.checkBoxIncludeReference.AutoSize = true;
            this.checkBoxIncludeReference.Checked = true;
            this.checkBoxIncludeReference.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeReference.Location = new System.Drawing.Point(12, 100);
            this.checkBoxIncludeReference.Name = "checkBoxIncludeReference";
            this.checkBoxIncludeReference.Size = new System.Drawing.Size(150, 17);
            this.checkBoxIncludeReference.TabIndex = 5;
            this.checkBoxIncludeReference.Text = "Include Reference Palette";
            this.checkBoxIncludeReference.UseVisualStyleBackColor = true;
            this.checkBoxIncludeReference.CheckedChanged += new System.EventHandler(this.checkBoxIncludeReference_CheckedChanged);
            // 
            // groupBoxReference
            // 
            this.groupBoxReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReference.Controls.Add(this.labelThresholdIndexedPercent);
            this.groupBoxReference.Controls.Add(this.numericUpDownThresholdIndexed);
            this.groupBoxReference.Controls.Add(this.labelThresholdIndexed);
            this.groupBoxReference.Controls.Add(this.labelThresholdMatchedPercent);
            this.groupBoxReference.Controls.Add(this.numericUpDownThresholdMatched);
            this.groupBoxReference.Controls.Add(this.labelThresholdMatched);
            this.groupBoxReference.Controls.Add(this.numericUpDownDistance);
            this.groupBoxReference.Controls.Add(this.labelDistance);
            this.groupBoxReference.Controls.Add(this.labelReferencePaletteFile);
            this.groupBoxReference.Controls.Add(this.textBoxFileNameReference);
            this.groupBoxReference.Location = new System.Drawing.Point(12, 123);
            this.groupBoxReference.Name = "groupBoxReference";
            this.groupBoxReference.Size = new System.Drawing.Size(514, 165);
            this.groupBoxReference.TabIndex = 6;
            this.groupBoxReference.TabStop = false;
            this.groupBoxReference.Text = "Reference Palette";
            // 
            // labelThresholdIndexedPercent
            // 
            this.labelThresholdIndexedPercent.AutoSize = true;
            this.labelThresholdIndexedPercent.Location = new System.Drawing.Point(182, 107);
            this.labelThresholdIndexedPercent.Name = "labelThresholdIndexedPercent";
            this.labelThresholdIndexedPercent.Size = new System.Drawing.Size(15, 13);
            this.labelThresholdIndexedPercent.TabIndex = 6;
            this.labelThresholdIndexedPercent.Text = "%";
            // 
            // numericUpDownThresholdIndexed
            // 
            this.numericUpDownThresholdIndexed.DecimalPlaces = 2;
            this.numericUpDownThresholdIndexed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownThresholdIndexed.Location = new System.Drawing.Point(113, 105);
            this.numericUpDownThresholdIndexed.Name = "numericUpDownThresholdIndexed";
            this.numericUpDownThresholdIndexed.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownThresholdIndexed.TabIndex = 5;
            // 
            // labelThresholdIndexed
            // 
            this.labelThresholdIndexed.AutoSize = true;
            this.labelThresholdIndexed.Location = new System.Drawing.Point(5, 107);
            this.labelThresholdIndexed.Name = "labelThresholdIndexed";
            this.labelThresholdIndexed.Size = new System.Drawing.Size(95, 13);
            this.labelThresholdIndexed.TabIndex = 4;
            this.labelThresholdIndexed.Text = "Threshold Indexed";
            // 
            // labelThresholdMatchedPercent
            // 
            this.labelThresholdMatchedPercent.AutoSize = true;
            this.labelThresholdMatchedPercent.Location = new System.Drawing.Point(182, 136);
            this.labelThresholdMatchedPercent.Name = "labelThresholdMatchedPercent";
            this.labelThresholdMatchedPercent.Size = new System.Drawing.Size(15, 13);
            this.labelThresholdMatchedPercent.TabIndex = 9;
            this.labelThresholdMatchedPercent.Text = "%";
            // 
            // numericUpDownThresholdMatched
            // 
            this.numericUpDownThresholdMatched.Location = new System.Drawing.Point(113, 134);
            this.numericUpDownThresholdMatched.Name = "numericUpDownThresholdMatched";
            this.numericUpDownThresholdMatched.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownThresholdMatched.TabIndex = 8;
            this.numericUpDownThresholdMatched.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelThresholdMatched
            // 
            this.labelThresholdMatched.AutoSize = true;
            this.labelThresholdMatched.Location = new System.Drawing.Point(5, 136);
            this.labelThresholdMatched.Name = "labelThresholdMatched";
            this.labelThresholdMatched.Size = new System.Drawing.Size(99, 13);
            this.labelThresholdMatched.TabIndex = 7;
            this.labelThresholdMatched.Text = "Threshold Matched";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Location = new System.Drawing.Point(113, 76);
            this.numericUpDownDistance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownDistance.TabIndex = 3;
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(5, 78);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(99, 13);
            this.labelDistance.TabIndex = 2;
            this.labelDistance.Text = "Max Color Distance";
            // 
            // labelCoverage
            // 
            this.labelCoverage.AutoSize = true;
            this.labelCoverage.Location = new System.Drawing.Point(12, 59);
            this.labelCoverage.Name = "labelCoverage";
            this.labelCoverage.Size = new System.Drawing.Size(53, 13);
            this.labelCoverage.TabIndex = 2;
            this.labelCoverage.Text = "Coverage";
            // 
            // numericUpDownCoverage
            // 
            this.numericUpDownCoverage.Location = new System.Drawing.Point(99, 57);
            this.numericUpDownCoverage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCoverage.Name = "numericUpDownCoverage";
            this.numericUpDownCoverage.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownCoverage.TabIndex = 3;
            this.numericUpDownCoverage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelCoveragePercentage
            // 
            this.labelCoveragePercentage.AutoSize = true;
            this.labelCoveragePercentage.Location = new System.Drawing.Point(168, 59);
            this.labelCoveragePercentage.Name = "labelCoveragePercentage";
            this.labelCoveragePercentage.Size = new System.Drawing.Size(15, 13);
            this.labelCoveragePercentage.TabIndex = 4;
            this.labelCoveragePercentage.Text = "%";
            // 
            // FormImagePalette
            // 
            this.AcceptButton = this.buttonGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(539, 350);
            this.Controls.Add(this.labelCoveragePercentage);
            this.Controls.Add(this.numericUpDownCoverage);
            this.Controls.Add(this.labelCoverage);
            this.Controls.Add(this.groupBoxReference);
            this.Controls.Add(this.checkBoxIncludeReference);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.labelFileOrDirectory);
            this.Name = "FormImagePalette";
            this.Text = "Image Palette";
            this.Load += new System.EventHandler(this.FormImagePalette_Load);
            this.groupBoxReference.ResumeLayout(false);
            this.groupBoxReference.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIndexed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdMatched)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoverage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFileOrDirectory;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelReferencePaletteFile;
        private System.Windows.Forms.TextBox textBoxFileNameReference;
        private System.Windows.Forms.CheckBox checkBoxIncludeReference;
        private System.Windows.Forms.GroupBox groupBoxReference;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.Label labelThresholdMatchedPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownThresholdMatched;
        private System.Windows.Forms.Label labelThresholdMatched;
        private System.Windows.Forms.Label labelCoverage;
        private System.Windows.Forms.NumericUpDown numericUpDownCoverage;
        private System.Windows.Forms.Label labelCoveragePercentage;
        private System.Windows.Forms.Label labelThresholdIndexed;
        private System.Windows.Forms.Label labelThresholdIndexedPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownThresholdIndexed;
    }
}

