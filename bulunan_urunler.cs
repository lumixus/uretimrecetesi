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
    public partial class bulunan_urunler : Form
    {
        public bulunan_urunler()
        {
            InitializeComponent();

            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_bulunan_urunler();
            yeni.baglantikapat();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bulunan_urunler_Load(object sender, EventArgs e)
        {

        }
    }
}
