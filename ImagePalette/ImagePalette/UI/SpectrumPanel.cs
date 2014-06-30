using System;
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
        private Graphics graphicsSpectrum;

        /// <summary>
        /// Key = Indexed color, Value = Matched color
        /// </summary>
        private Dictionary<Color, Color> matchedColors;

        public SpectrumPanel()
        {
            InitializeComponent();
        }

        private void SpectrumPanel_Load(object sender, EventArgs e)
        {
            matchedColors = new Dictionary<Color, Color>();
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

            CreateMatchedColors();
            PaintPanel();
        }

        private void PaintPanel()
        {
            PaintSpectrum();

            if (matchedColors.Count > 0)
                PaintMatchedColors();
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
            graphicsSpectrum = panel.CreateGraphics();

            for (double i = 0, x = 0; i < 1; i += colorIncrease, x += posIncrease)
            {
                Color color = ColorUtil.HSL2RGB(i, 0.5, 0.5);
                SolidBrush brush = new SolidBrush(color);

                location.X = (int)x;
                Rectangle rect = new Rectangle(location, size);
                
                graphicsSpectrum.FillRectangle(brush, rect);
            }
        }

        private void CreateMatchedColors()
        {
            if (dgvIndexed != null)
            {
                matchedColors.Clear();
                foreach (DataRowView row in dgvIndexed.Rows)
                    matchedColors.Add((Color)row[PaletteGridColumns.Color], (Color)row[PaletteGridColumns.Match]);
            }
        }

        private void PaintCircle(Graphics g, Point position)
        {
        }

        private void PaintMatchedColors()
        {
            //TODO: finish
            //foreach (Color indexed in matchedColors.Keys)
        }
    }
}
