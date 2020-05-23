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
    public partial class kesim_durumu : Form
    {
        
        public kesim_durumu()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.selectKesim();
            yeni.baglantikapat();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime ktar = dateTimePicker1.Value;
            string kmal = textBox2.Text;
            string kmik = textBox4.Text;
            DateTime svertar = dateTimePicker2.Value;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertKesim(ktar,kmal,kmik,svertar);
            dataGridView1.DataSource = yeni.selectKesim();
            yeni.baglantikapat();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteKesim(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Kesim Silindi");
            dataGridView1.DataSource = yeni.selectKesim();
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var degisken = textBox1.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = yeni.searchKesimID(degisken);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchKesilenMal(degisken);
            }
            yeni.baglantikapat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UpdateKesim(Convert.ToInt32(textBox3.Text),dateTimePicker1.Value, textBox2.Text,textBox4.Text,dateTimePicker2.Value);
            dataGridView1.DataSource = yeni.selectKesim();
            yeni.baglantikapat();
        }

        private void kesim_durumu_Load(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            if (textBox3.Text == "")
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
            {
                MessageBox.Show("Dolu olan bir satır seçilmelidir !");
            }
            else
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                if (textBox3.Text == "")
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
}
