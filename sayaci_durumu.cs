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
    public partial class sayaci_durumu : Form
    {
        public sayaci_durumu()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteSayaci(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Personel Silindi");
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var degisken = textBox1.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = yeni.searchsayaciID(degisken);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchverilis_tar(degisken);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = yeni.searchyapilan_urun(degisken);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string urun = textBox4.Text;
            DateTime vertar = dateTimePicker1.Value;
            DateTime geltar = dateTimePicker2.Value;

            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertsayaci(vertar, geltar, urun);
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
