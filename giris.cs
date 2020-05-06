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
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "123")
            {

                yoneticipaneli yonetici = new yoneticipaneli();
                yonetici.Show();
                this.Hide();
            }
            else
                MessageBox.Show("HATALI", "GİRİŞ");
        }

        private void giris_FormClosing(object sender, FormClosingEventArgs e)
        {
                    Application.Exit();
        }
    }
}
