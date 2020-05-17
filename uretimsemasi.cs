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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertUretimSemasi(textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox6.Text));
            dataGridView1.DataSource = yeni.select_uretim();
            yeni.baglantikapat();
        }
    }
}
