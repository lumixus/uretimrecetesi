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
            if (textBox8.Text == "")
            {
                button5.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                button5.Enabled = true;
                button1.Enabled = false;
            }
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
            var degisken = textBox7.Text;
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

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UpdateBulunan(Convert.ToInt32(textBox8.Text), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            dataGridView1.DataSource = yeni.selectPersonel();
            yeni.baglantikapat();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
            {
                MessageBox.Show("Dolu olan bir satır seçilmelidir !");
            }
            else
            {
                textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                if (textBox8.Text == "")
                {
                    button5.Enabled = false;
                    button1.Enabled = true;
                }
                else
                {
                    button5.Enabled = true;
                    button1.Enabled = false;
                }
            }
        }
    }
}
