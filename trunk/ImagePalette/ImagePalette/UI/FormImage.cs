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
        private string title;
        private Image image;

        public FormImage(string title, Image image)
        {
            InitializeComponent();
            this.title = title;
            this.image = image;
        }

        private void FormImage_Load(object sender, EventArgs e)
        {
            Text = title;
            pictureBox.Image = image;
        }
    }
}
