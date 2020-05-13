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
    }
}
