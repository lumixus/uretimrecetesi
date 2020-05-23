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
using Excel = Microsoft.Office.Interop.Excel;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.StandardFontSize = 14;
            var range = xlWorkSheet.get_Range("A1","D1");
           
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                }
            }

            xlWorkSheet.Columns.AutoFit();
            xlWorkSheet.Rows.AutoFit();

            xlWorkBook.SaveAs(saveFileDialog1.FileName + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("Excell'e Aktarıldı");
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
