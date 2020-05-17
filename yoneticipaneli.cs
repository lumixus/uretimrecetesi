using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace uretimrecetesi
{
 
    public partial class yoneticipaneli : Form
    {
       
        private bool Kapatsorgu;
        DialogResult dr = DialogResult.No;
        public yoneticipaneli()
        {
            InitializeComponent();
           
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_hammadde();
            label4.Text = yeni.personel_sayisi().ToString();
            dataGridView2.DataSource = yeni.select_gunceluretim();
            dataGridView3.DataSource = yeni.select_stoklariazalanlar();
            yeni.baglantikapat();
        }
       
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }
        
        private void yoneticipaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Kapatsorgu) 
            {
                dr = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Kapatsorgu = dr == DialogResult.Yes;
            }
            if (dr == DialogResult.Yes)
            {
                if (Kapatsorgu) 
                {
                    
                    Application.Exit();
                    
                }
                Kapatsorgu = false;
            }
            else
            {
                e.Cancel = true;
            }
        }



        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personeller personel = new Personeller();
            personel.Show();
        }

        private void hammaddeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hammaddeler hammadde = new hammaddeler();
            hammadde.Show();
        }

        private void üretileceklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bulunan_urunler bulunanurunler = new bulunan_urunler();
            bulunanurunler.Show();
        }

        private void sevkiyatMalzemeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sevkiyat_malzemeleri sevkiyatmalzemeleri = new sevkiyat_malzemeleri();
            sevkiyatmalzemeleri.Show();
        }

        private void güncelÜretimDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guncel_uretim gunceluretim = new guncel_uretim();
            gunceluretim.Show();
        }

        private void kesimDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kesim_durumu kesimdurumu = new kesim_durumu();
            kesimdurumu.Show();
        }

        private void sayacıDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sayaci_durumu sayacidurumu = new sayaci_durumu();
            sayacidurumu.Show();
        }

        private void yoneticipaneli_Load(object sender, EventArgs e)
        {

        }

        private void üretimŞemalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uretimsemasi uretimsemasi = new uretimsemasi();
            uretimsemasi.Show();
        }
    }
}
