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
            var alanlar = yeni.select_hammaddeAlanlari();
            var i = 0;
            while (alanlar.Read())
            {
                comboBox1.Items.Add(alanlar.GetName(i));
                i++;
            }
            yeni.baglantikapat();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
