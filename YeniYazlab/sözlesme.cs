using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YeniYazlab
{
    public partial class sözlesme : Form
    {
        public sözlesme()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            bilgi bilgi = new bilgi();
            bilgi.Show();
            this.Close();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void label17_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label17_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label17_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
