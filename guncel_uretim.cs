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
    }
}
