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

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.deletePersonel(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
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

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            string cinsiyet = "";
            if (radioButton1.Checked)
            {
                cinsiyet = "Erkek";
            }
            else
            {
                cinsiyet = "Kadın";
            }
            yeni.UpdatePersonel(Convert.ToInt32(textBox7.Text),textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,dateTimePicker1.Value,comboBox2.Text,cinsiyet, textBox6.Text);
            dataGridView1.DataSource = yeni.selectPersonel();
            yeni.baglantikapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            if (textBox7.Text == "")
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
                textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

                if (textBox7.Text == "")
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

        private void Personeller_Load(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
