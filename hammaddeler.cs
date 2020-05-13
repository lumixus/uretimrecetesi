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
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteHammadde(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Hammadde Silindi");
            dataGridView1.DataSource = yeni.select_hammaddeler();
            yeni.baglantikapat();
     
        }




    }
}
