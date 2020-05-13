using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uretimrecetesi
{
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.selectPersonel();
            yeni.baglantikapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deletePersonel(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Personel Silindi");
            dataGridView1.DataSource = yeni.selectPersonel();
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var degisken = textBox1.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if(comboBox1.SelectedIndex == 0) {
                dataGridView1.DataSource = yeni.searchpersonelID(degisken);
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchPersonelAdi(degisken);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = yeni.searchPersonelSoyadi(degisken);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.DataSource = yeni.searchPersoneltc(degisken);
            }
            yeni.baglantikapat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox2.Text;
            string soyad = textBox3.Text;
            string tc = textBox4.Text;
            string tel = textBox5.Text;
            DateTime isbas = dateTimePicker1.Value;
            string mail = textBox6.Text;
            string gorev = comboBox2.Text;
            string cinsiyet = "";
            if (radioButton1.Checked)
            {
                cinsiyet = "Erkek";
            }
            else
            {
                cinsiyet = "Kadın";
            }
            baglanti yeni = new baglanti();
            yeni.baglandimi();
           yeni.insertPersonel(ad, soyad, tc, tel, isbas, gorev, mail, cinsiyet);
            dataGridView1.DataSource = yeni.selectPersonel();
            yeni.baglantikapat();
        }
    }
}
