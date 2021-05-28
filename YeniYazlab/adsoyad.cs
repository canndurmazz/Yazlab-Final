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
    public partial class adsoyad : Form
    {

        
        public adsoyad()
        {
            InitializeComponent();
           
        }
      
        private void label3_Click(object sender, EventArgs e)
        {
           
                       
       }

        private void adsoyad_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void adtext_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void soyadtext_KeyDown(object sender, KeyEventArgs e)
        {
        }
        public string adisim;
        public string soyadisim;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(add.Text) == true || string.IsNullOrEmpty(soyadd.Text) == true || add.Text == "Adınız" || soyadd.Text =="Soyadınız" )
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                adisim = add.Text;
                soyadisim = soyadd.Text;
               giris giris = new giris();
                giris.ad = adisim;
                giris.soyad = soyadisim;

                    
                                         
                giris.Show();
                this.Hide();
            }
        }
        private bool mouseDown;
        private Point lastLocation;
        private void adsoyad_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void adsoyad_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void adsoyad_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void adtext_Click(object sender, EventArgs e)
        {
           
        }

        private void soyadtext_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Click(object sender, EventArgs e)
        {
           
        }
   

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void soyadtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
