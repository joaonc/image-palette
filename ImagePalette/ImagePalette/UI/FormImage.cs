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
    public partial class FormImage : Form
    {
        public FormImage(string title)
        {
            InitializeComponent();
            Text = title;
        }

        private void FormImage_Load(object sender, EventArgs e)
        {
        }

        public Image Image
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }
    }
}
