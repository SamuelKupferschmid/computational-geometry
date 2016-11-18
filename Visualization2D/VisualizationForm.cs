using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualization2D
{
    public partial class VisualizationForm : Form
    {
        public Drawing Drawing;

        public VisualizationForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Drawing?.DrawGraphics(e.Graphics);
        }
    }
}
