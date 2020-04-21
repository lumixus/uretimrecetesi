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
        private bool Kapatsorgu;
        DialogResult dr = DialogResult.No;
        public yoneticipaneli()
        {
            InitializeComponent();
        }

        private void yoneticipaneli_Load(object sender, EventArgs e)
        {
            
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void yoneticipaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Kapatsorgu) 
            {
                dr = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Kapatsorgu = dr == DialogResult.Yes;
            }
            if (dr == DialogResult.Yes)
            {
                if (Kapatsorgu) 
                {
                    
                    Application.Exit();
                }
                Kapatsorgu = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
