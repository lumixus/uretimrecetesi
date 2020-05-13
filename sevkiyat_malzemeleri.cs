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
    }
}
