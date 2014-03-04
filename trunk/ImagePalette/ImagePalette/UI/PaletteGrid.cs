using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePalette
{
    /// <summary>
    /// Adds a bit more functionality to the DataGridView that represents a palette.
    /// Need to build the DataTable outside of this class and the instance used in
    /// the constructor or setter will be bound (DataSource) to the DataGridView.
    /// </summary>
    public partial class PaletteGrid : UserControl
    {
        public PaletteGrid()
        {
            InitializeComponent();
        }

        public PaletteGrid(DataTable dt)
        {
            InitializeComponent();
            DataTable = dt;
        }

        public DataTable DataTable
        {
            get { return (DataTable)dataGridView.DataSource; }
            set
            {
                if (value != null)
                    VerifyColumns(value);

                dataGridView.DataSource = value;
            }
        }

        public DataGridView DataGridView
        {
            get { return dataGridView; }
        }

        private void PaletteGrid_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Make sure the DataTable only contains expected columns.
        /// </summary>
        /// <param name="dt"></param>
        private void VerifyColumns(DataTable dt)
        {
            List<string> rejectedColumns = new List<string>();
            List<string> possibleColumns = PaletteGridColumns.GetColumnNames();
            foreach (DataColumn col in dt.Columns)
                if (!possibleColumns.Contains(col.ColumnName))
                    rejectedColumns.Add(col.ColumnName);

            if (rejectedColumns.Count > 0)
                throw new Exception("The following columns are not permitted: " + string.Join(", ", rejectedColumns));
        }

        private void SetColumnWidths()
        {
            foreach (DataGridViewColumn col in DataGridView.Columns)
            {
                if (col.Name.Equals(PaletteGridColumns.Count) || col.Name.Equals(PaletteGridColumns.Hex))
                    col.Width = 50;
                else if (col.Name.Equals(PaletteGridColumns.Color))
                    col.Width = 35;
                else
                    col.Width = 30;

                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            SetColumnWidths();
            DataGridView.CurrentCell = null;  // Select no cell to avoid mixing the color of selection with the color of the cell
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Set the color of the cells in the "Color" column
            // This needs to be done both on new object being bound AND after sorting
            // This event is called on both those occasions
            if (e.ListChangedType == ListChangedType.Reset && dataGridView.Columns.Contains(PaletteGridColumns.Color))
            {
                DataGridView dgv = (DataGridView)sender;
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dgv.Rows[i];
                    Color color = GetColorInRow(row);
                    dgv.Rows[i].Cells[PaletteGridColumns.Color].Style.BackColor = color;
                }
            }
        }

        public Color GetColorInRow(int rowIndex)
        {
            return GetColorInRow(DataGridView.Rows[rowIndex]);
        }

        public Color GetColorInRow(DataGridViewRow row)
        {
            return Color.FromArgb(
                (int)row.Cells[PaletteGridColumns.A].Value,
                (int)row.Cells[PaletteGridColumns.R].Value,
                (int)row.Cells[PaletteGridColumns.G].Value,
                (int)row.Cells[PaletteGridColumns.B].Value);
        }

        public List<Color> GetAllColors()
        {
            List<Color> colors = new List<Color>();
            
            foreach(DataGridViewRow row in DataGridView.Rows)
                colors.Add(GetColorInRow(row));

            return colors;
        }
    }
}
