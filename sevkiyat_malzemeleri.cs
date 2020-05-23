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
    public partial class sevkiyat_malzemeleri : Form
    {
        public sevkiyat_malzemeleri()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.selectSevkiyat();
            yeni.baglantikapat();
        }

        private void sevkiyat_malzemeleri_Load(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
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
            string smal = textBox1.Text;
            string smalmik = textBox2.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertSevkiyat(smal,smalmik);
            dataGridView1.DataSource = yeni.selectSevkiyat();
            yeni.baglantikapat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteSevkiyat(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Sevkiyat Malzemesi Silindi");
            dataGridView1.DataSource = yeni.selectSevkiyat();
            yeni.baglantikapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var degisken = textBox4.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = yeni.searchSevkiyatID(degisken);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchSevkiyatMalzemeAdi(degisken);
            }
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
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (textBox3.Text == "")
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            if (textBox3.Text == "")
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

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UpdateSevkiyat(Convert.ToInt32(textBox3.Text), textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = yeni.selectSevkiyat();
            yeni.baglantikapat();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
