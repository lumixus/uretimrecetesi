using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace uretimrecetesi
{
    public partial class guncel_uretim : Form
    {
        public guncel_uretim()
        {
            InitializeComponent();

            baglanti yeni = new baglanti();
            yeni.baglandimi();
            
            dataGridView1.DataSource = yeni.select_uretim();
            dataGridView2.DataSource =yeni.select_gunceluretim() ;
            yeni.baglantikapat();

        }

        private void guncel_uretim_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            comboBox1.Items.Clear();
            foreach(DataRow row in yeni.select_uretimsemasi().Rows)
            {
               comboBox1.Items.Add(row.Field<string>("uretilecek_urun"));
            }
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UretimeEkle(Convert.ToInt32(textBox2.Text), comboBox1.Text);

            dataGridView2.DataSource = yeni.select_gunceluretim();
                yeni.baglantikapat();
        }
    }
}
