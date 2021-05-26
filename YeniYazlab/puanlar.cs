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
  
    public partial class puanlar : Form
    {
        public SqlConnection baglanti;
        public puanlar()
        {
            InitializeComponent();
        }
        public void kolaypuan()
        {
            try
            {
                dataGridView1.Visible = true;
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select ad, soyad, puan from oyuncular where zorluk = 'kolay'", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        public void ortapuan()
        {
            try
            {
                dataGridView1.Visible = true;
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select ad, soyad, puan from oyuncular where zorluk = 'orta'", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        public void zorpuan()
        {
            try
            {
                dataGridView1.Visible = true;
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select ad, soyad, puan from oyuncular where zorluk = 'zor'", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            kolaypuan();
        }

        private void puanlar_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ortapuan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zorpuan();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void puanlar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void puanlar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void puanlar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
