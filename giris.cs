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
    public partial class giris : Form
    {
       int usercount;
        public giris()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            usercount = yeni.GetUser(textBox1.Text,textBox2.Text);
            yeni.baglantikapat();
            if (usercount == 1)
            {

                yoneticipaneli yonetici = new yoneticipaneli();
                yonetici.Show();
                this.Hide();
            }
            else { 
                MessageBox.Show("HATALI", "GİRİŞ");
            }
        }

        private void giris_FormClosing(object sender, FormClosingEventArgs e)
        {
                    Application.Exit();
        }
    }
}
