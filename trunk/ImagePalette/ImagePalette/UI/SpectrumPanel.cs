﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePalette.UI
{
    public partial class SpectrumPanel : UserControl
    {
        private DataGridView dgvIndexed;
        private ImagePaletteParameters parameters;
        Graphics graphics;

        public SpectrumPanel()
        {
            InitializeComponent();
        }

        private void SpectrumPanel_Load(object sender, EventArgs e)
        {
            PaintPanel();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            PaintPanel();
        }

        public void SetData(DataGridView dgvIndexed, ImagePaletteParameters parameters)
        {
            this.dgvIndexed = dgvIndexed;
            this.parameters = parameters;

            PaintPanel();
        }

        private void PaintPanel()
        {
            PaintSpectrum();
            PaintIndexed();
        }

        private void PaintSpectrum()
        {
            // Create the color spectrum.
            // From http://stackoverflow.com/questions/2288498/how-do-i-get-a-rainbow-color-gradient-in-c

            int numColors = 100;
            double colorIncrease = 1d / (double)numColors;
            double posIncrease = (double)panel.Width / (double)numColors;
            Size size = new Size(Convert.ToInt16(Math.Ceiling(posIncrease)), panel.Height);
            Point location = new Point(0, 0);
            graphics = panel.CreateGraphics();

            for (double i = 0, x = 0; i < 1; i += colorIncrease, x += posIncrease)
            {
                Color color = ColorUtil.HSL2RGB(i, 0.5, 0.5);
                SolidBrush brush = new SolidBrush(color);

                location.X = (int)x;
                Rectangle rect = new Rectangle(location, size);
                
                graphics.FillRectangle(brush, rect);
            }
        }

        private void PaintIndexed()
        {
            if (dgvIndexed != null)
            {
                foreach (DataRowView row in dgvIndexed.Rows)
                {

                }
            }
        }
    }
}
