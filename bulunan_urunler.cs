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
    public partial class bulunan_urunler : Form
    {
        public bulunan_urunler()
        {
            InitializeComponent();

            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_bulunan_urunler();
            yeni.baglantikapat();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bulunan_urunler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string ad = textBox1.Text;
            string adet = textBox2.Text;
            string fiyat = textBox3.Text;
            string model = textBox4.Text;
            string numara = textBox5.Text;
            string rengi = textBox6.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertBulunan(ad, adet, fiyat, model, numara,rengi);
            dataGridView1.DataSource = yeni.selectBulunan();
            yeni.baglantikapat();


        }

        private void button6_Click(object sender, EventArgs e)
        {
             baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteBulunan(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Personel Silindi");
            dataGridView1.DataSource = yeni.selectBulunan();
            yeni.baglantikapat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var degisken = textBox1.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = yeni.searchBulunanID(degisken);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchBulananadi(degisken);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = yeni.searchBulananmodel(degisken);
            }
            yeni.baglantikapat();
        }
    }
}
