using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.Sql;
using System.Data.SqlClient;

namespace YeniYazlab
{
    public partial class ortaseviye : Form
    {
        public SqlConnection baglanti;
        Image[] resimler =
        {
            Properties.Resources.aslanhayvan,
            Properties.Resources.fare,
            Properties.Resources.fil,
            Properties.Resources.kanarya,
            Properties.Resources.kartal,
            Properties.Resources.kedi,
            Properties.Resources.kurt,
            Properties.Resources.leopar,
            Properties.Resources.ordek,
            Properties.Resources.zurafa,

        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5,6,6,7,7,8,8,9,9,10,10 };

        PictureBox ilkkutu;
        int ilkIndeks, bulunan, deneme, puan;

        public string adgelen;
        public string soyadgelen;
        public ortaseviye()
        {
            InitializeComponent();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int kalansure = 240 - i;
            sure.Text = Convert.ToString(kalansure);
            i++;
            if (i == 240)
            {
                SoundPlayer ses9 = new SoundPlayer();
                string dizin9 = Application.StartupPath + "\\aaa.wav";
                ses9.SoundLocation = dizin9;
                ses9.Play();
                adsoyad adsoyad = new adsoyad();
                string ad = adsoyad.add.Text;
                string soyad = adsoyad.soyadd.Text;
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayitt = "insert into oyuncular(ad,soyad,puan,zorluk) values (@ad,@soyad,@puan,@zorluk)";
                SqlCommand komutt = new SqlCommand(kayitt, baglanti);
                komutt.Parameters.Add("@ad", SqlDbType.VarChar, 50).Value = adgelen;
                komutt.Parameters.Add("@soyad", SqlDbType.VarChar, 50).Value = soyadgelen;
                komutt.Parameters.Add("@puan", SqlDbType.Int, 50).Value = puan;
                komutt.Parameters.Add("@zorluk", SqlDbType.VarChar, 50).Value = "Orta";
                komutt.ExecuteNonQuery();
                MessageBox.Show("Süreniz Bitti, Oyun Yarım kaldı" + " " + deneme + " " + "Kez Deneme Yaptınız."
                    + Environment.NewLine +
                    "Toplam Paunınız =" + " " + puan, "Yeni Oyuna Geçiliyor.");
                bulunan = 0;
                deneme = 0;
                i = 0;

                foreach (Control kontrol in Controls)
                {
                    kontrol.Visible = true;
                }
                resimleriKaristir();
            }
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
        private void ortaseviye_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void ortaseviye_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void ortaseviye_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ortaseviye_Load(object sender, EventArgs e)
        {
            timer1.Start();
            resimleriKaristir();
        }
        private void resimleriKaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int sayi = rnd.Next(20);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        } 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo - 1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();
            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;

            }
            else
            {
                adsoyad adsoyad = new adsoyad();
                string ad = adsoyad.add.Text;
                string soyad = adsoyad.soyadd.Text;
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = null;
                kutu.Image = null;
                if (ilkIndeks == indeksNo)
                {
                    SoundPlayer ses = new SoundPlayer();
                    string dizin = Application.StartupPath + "\\basarili.wav";
                    ses.SoundLocation = dizin;
                    ses.Play();
                    puan = puan + 100;
                    label1.Text = Convert.ToString(puan);
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    if (bulunan == 10)
                    {
                        SoundPlayer ses5 = new SoundPlayer();
                        string dizin5 = Application.StartupPath + "\\alkis.wav";
                        ses5.SoundLocation = dizin5;
                        ses5.Play();
                        if (baglanti.State == ConnectionState.Closed)
                            baglanti.Open();
                        string kayitt = "insert into oyuncular(ad,soyad,puan,zorluk) values (@ad,@soyad,@puan,@zorluk)";
                        SqlCommand komutt = new SqlCommand(kayitt, baglanti);
                        komutt.Parameters.Add("@ad", SqlDbType.VarChar, 50).Value = adgelen;
                        komutt.Parameters.Add("@soyad", SqlDbType.VarChar, 50).Value = soyadgelen;
                        komutt.Parameters.Add("@puan", SqlDbType.Int, 50).Value = puan;
                        komutt.Parameters.Add("@zorluk", SqlDbType.VarChar, 50).Value = "Orta";
                        komutt.ExecuteNonQuery();
                        MessageBox.Show("Tebrikler, Oyunu" + " " + deneme + " " + "denemede bitirdiniz."
                            + Environment.NewLine +
                            "Toplam Paunınız =" + " " + puan, "Yeni Oyuna Geçiliyor.");
                        bulunan = 0;
                        deneme = 0;
                        i = 0;
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimleriKaristir();
                    }

                }
                else
                {
                    SoundPlayer ses = new SoundPlayer();
                    string dizin = Application.StartupPath + "\\basarisiz.wav";
                    ses.SoundLocation = dizin;
                    ses.Play();
                    puan = puan - 10;
                    label1.Text = Convert.ToString(puan);
                }
                ilkkutu = null;
            }
        }

    }
}
