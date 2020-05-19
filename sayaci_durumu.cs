using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace uretimrecetesi
{
    public partial class sayaci_durumu : Form
    {
        public sayaci_durumu()
        {
            InitializeComponent();
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yeni.deleteSayaci(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
            MessageBox.Show("Personel Silindi");
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var degisken = textBox1.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = yeni.searchsayaciID(degisken);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = yeni.searchverilis_tar(degisken);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = yeni.searchyapilan_urun(degisken);
            }
            yeni.baglantikapat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string urun = textBox4.Text;
            DateTime vertar = dateTimePicker1.Value;
            DateTime geltar = dateTimePicker2.Value;
            var sayaciadi = textBox2.Text;
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.insertsayaci(vertar, geltar, urun,sayaciadi);
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Student1";
            xlWorkSheet.Cells[1, 3] = "Student2";
            xlWorkSheet.Cells[1, 4] = "Student3";

            xlWorkSheet.Cells[2, 1] = "Term1";
            xlWorkSheet.Cells[2, 2] = "80";
            xlWorkSheet.Cells[2, 3] = "65";
            xlWorkSheet.Cells[2, 4] = "45";

            xlWorkSheet.Cells[3, 1] = "Term2";
            xlWorkSheet.Cells[3, 2] = "78";
            xlWorkSheet.Cells[3, 3] = "72";
            xlWorkSheet.Cells[3, 4] = "60";

            xlWorkSheet.Cells[4, 1] = "Term3";
            xlWorkSheet.Cells[4, 2] = "82";
            xlWorkSheet.Cells[4, 3] = "80";
            xlWorkSheet.Cells[4, 4] = "65";

            xlWorkSheet.Cells[5, 1] = "Term4";
            xlWorkSheet.Cells[5, 2] = "75";
            xlWorkSheet.Cells[5, 3] = "82";
            xlWorkSheet.Cells[5, 4] = "68";

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d5");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            xlWorkBook.SaveAs("test.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
       
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
