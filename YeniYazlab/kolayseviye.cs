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
    public partial class kolayseviye : Form
    {

        public int sol = 0x00080000;

        public SqlConnection baglanti;
        Image[] resimler =
        {
            Properties.Resources.aslanagzi,
            Properties.Resources.gelin,
            Properties.Resources.gul,
            Properties.Resources.orkide,
            Properties.Resources.papatya,  
   
        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};

        PictureBox ilkkutu;
        int ilkIndeks, bulunan, deneme, puan;
        public kolayseviye()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
      
        public string adgelen;
        public string soyadgelen;
        
     
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
         
            int kalansure = 120 - i;
            sure.Text = Convert.ToString(kalansure);
            i++;
            if (i ==120)
            {
                
                SoundPlayer ses9 = new SoundPlayer();
                string dizin9 = Application.StartupPath + "\\aaa.wav";
                ses9.SoundLocation = dizin9;
                ses9.Play();
          
               
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayitt = "insert into oyuncular(ad,soyad,puan,zorluk) values (@ad,@soyad,@puan,@zorluk)";
                SqlCommand komutt = new SqlCommand(kayitt, baglanti);
                komutt.Parameters.Add("@ad",SqlDbType.VarChar,50).Value=adgelen;
                komutt.Parameters.Add("@soyad", SqlDbType.VarChar, 50).Value = soyadgelen;
                komutt.Parameters.Add("@puan", SqlDbType.Int, 50).Value = puan;
                komutt.Parameters.Add("@zorluk", SqlDbType.VarChar, 50).Value = "Kolay";
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
        private bool mouseDown;
        private Point lastLocation;
        private void kolayseviye_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void kolayseviye_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void kolayseviye_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void kolayseviye_Load(object sender, EventArgs e)
        {
            timer1.Start();
            resimleriKaristir();
        }
       
        private void resimleriKaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int sayi = rnd.Next(10);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }
        public void blg()
        {
           
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
                    if (bulunan == 5)
                    {
                        SoundPlayer ses5 = new SoundPlayer();
                        string dizin5 = Application.StartupPath + "\\alkis.wav";
                        ses5.SoundLocation = dizin5;
                        ses5.Play();                       
                        if (baglanti.State == ConnectionState.Closed)
                            baglanti.Open();
                        try
                        {
                       
                         
                            string kayit = "insert into oyuncular(ad,soyad,puan,zorluk) values (@ad,@soyad,@puan,@zorluk)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                            komut.Parameters.Add("@ad", SqlDbType.VarChar, 50).Value = adgelen;
                            komut.Parameters.Add("@soyad", SqlDbType.VarChar, 50).Value = soyadgelen;
                            komut.Parameters.Add("@puan", SqlDbType.Int, 50).Value = puan;
                            komut.Parameters.Add("@zorluk", SqlDbType.VarChar, 50).Value = "Kolay";
                            komut.ExecuteNonQuery();
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
                        catch (Exception hata)
                        {

                            MessageBox.Show("HATA," + hata,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                       
                    }

                }
                else
                {
                    SoundPlayer ses = new SoundPlayer();
                    string dizin = Application.StartupPath + "\\basarisiz.wav";
                    ses.SoundLocation = dizin;
                    ses.Play();
                    puan = puan - 20;
                    label1.Text = Convert.ToString(puan);
                }
                ilkkutu = null;
            }
        }
    }
}
