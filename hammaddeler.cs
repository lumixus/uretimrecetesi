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
    public partial class hammaddeler : Form
    {
        public hammaddeler()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_hammaddeler();
            yeni.baglantikapat();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
               dataGridView1.DataSource = yeni.searchHammaddeID(textBox4.Text);
            }
            else
            {
               dataGridView1.DataSource = yeni.searchHammaddeAdi(textBox4.Text);
            }
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hammaddeadi = textBox1.Text;
            var hammaddemiktar = Convert.ToInt32(textBox2.Text);
            var alistar = dateTimePicker1.Value;
            var minmiktar = Convert.ToInt32(textBox3.Text);
            baglanti yeni = new baglanti();
            yeni.baglandimi();
           yeni.insertHammadde(hammaddeadi, hammaddemiktar, minmiktar, alistar);
            dataGridView1.DataSource = yeni.select_hammaddeler();
           yeni.baglantikapat();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.deleteHammadde(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            MessageBox.Show("Hammadde Silindi");
            dataGridView1.DataSource = yeni.select_hammaddeler();
            yeni.baglantikapat();
     
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UpdateHammadde(Convert.ToInt32(textBox5.Text), textBox1.Text, textBox2.Text,dateTimePicker1.Value,textBox3.Text);
            dataGridView1.DataSource = yeni.select_hammaddeler();
            yeni.baglantikapat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox5.Clear();
            if (textBox5.Text == "")
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

        private void hammaddeler_Load(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString())) {
                MessageBox.Show("Dolu olan bir satır seçilmelidir !");
            }
            else { 
            dateTimePicker1.Value = DateTime.Today;
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            DataTable test = yeni.select_hammaddeler();
            DateTime tarih = Convert.ToDateTime(test.Rows[dataGridView1.CurrentRow.Index]["alis_tar"]);
            dateTimePicker1.Value = tarih;
            yeni.baglantikapat();
            if (textBox5.Text == "")
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
