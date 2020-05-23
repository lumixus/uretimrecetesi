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
    public partial class uretimsemasi : Form
    {
        public uretimsemasi()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_uretim();
            yeni.baglantikapat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertUretimSemasi(textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox6.Text));
            dataGridView1.DataSource = yeni.select_uretim();
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var degisken = textBox1.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = yeni.searchuretimID(degisken);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchUretilecekurun(degisken);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = yeni.searchSunnideri(degisken);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.DataSource = yeni.searchDeri(degisken);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                dataGridView1.DataSource = yeni.searchBagcik(degisken);
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                dataGridView1.DataSource = yeni.searchİlac(degisken);
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                dataGridView1.DataSource = yeni.searchSalpa(degisken);
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                dataGridView1.DataSource = yeni.searchTaban(degisken);
            }
            yeni.baglantikapat();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteUretimsemasi(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Silindi");
            dataGridView1.DataSource = yeni.select_uretimsemasi();
            yeni.baglantikapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            if (textBox9.Text == "")
            {
                button5.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button5.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UpdateUretimSemasi(Convert.ToInt32(textBox9.Text),textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text, textBox6.Text);
            dataGridView1.DataSource = yeni.select_uretimsemasi();
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
                textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                if (textBox9.Text == "")
                {
                    button5.Enabled = false;
                    button2.Enabled = true;
                }
                else
                {
                    button5.Enabled = true;
                    button2.Enabled = false;
                }
            }
        }

        private void uretimsemasi_Load(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                button5.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button5.Enabled = true;
                button2.Enabled = false;
            }
        }
    }
}
