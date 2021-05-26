using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace YeniYazlab
{
    public partial class giris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANPC\\SQLEXPRESS;Initial Catalog=hafizavt;Integrated Security=True;MultipleActiveResultSets=True;");
       public string ad;
        public string soyad;
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kolayseviye kolayseviye = new kolayseviye();
            kolayseviye.baglanti = baglanti;
            kolayseviye.soyadgelen = soyad;
            kolayseviye.adgelen = ad;
            kolayseviye.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ortaseviye ortaseviye = new ortaseviye();
            ortaseviye.baglanti = baglanti;
            ortaseviye.adgelen = ad;
            ortaseviye.soyadgelen = soyad;           
            ortaseviye.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zorseviye zorseviye = new zorseviye();
            zorseviye.baglanti = baglanti;
            zorseviye.adgelen = ad;
            zorseviye.soyadgelen = soyad;            
            zorseviye.Show();
            this.Hide();
        }

        private void giris_Load(object sender, EventArgs e)
        {
    
            label3.Text = DateTime.Now.ToString();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            puanlar puanlar = new puanlar();
            puanlar.baglanti = baglanti;
            puanlar.Show();            
            this.Hide();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void giris_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void giris_MouseMove(object sender, MouseEventArgs e)
        {

            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void giris_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
