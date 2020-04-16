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
    public partial class yoneticipaneli : Form
    {
        public yoneticipaneli()
        {
            InitializeComponent();
        }

        private void yoneticipaneli_Load(object sender, EventArgs e)
        {
            
        }

        protected virtual void yoneticipaneli_FormClosed(object sender, FormClosedEventArgs e)
        {

            DialogResult Cikis;
            Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (Cikis == DialogResult.No)
            {
                Application.Run();
            }

        }

    }
}
