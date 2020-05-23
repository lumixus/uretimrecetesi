using DlhSoft.Windows.Data;
using Microsoft.SqlServer.Server;
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
            yeni.insertsayaci(vertar, geltar, urun, sayaciadi);
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti yeni = new baglanti();
            yeni.baglandimi();
            yeni.UpdateSayaciDurumu(Convert.ToInt32(textBox3.Text), dateTimePicker1.Value, dateTimePicker2.Value, textBox4.Text, textBox2.Text);
            dataGridView1.DataSource = yeni.select_sayaci();
            yeni.baglantikapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("BOŞ BIRAKILAMAZ");
            }
            else {
            var kayitsayisi = Convert.ToInt32(textBox5.Text);
            DateTime ilktarih;
            DateTime digertarih;
            saveFileDialog1.ShowDialog();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);

            Excel.Chart chartPage = myChart.Chart;
          //  chartRange = xlWorkSheet.get_Range("b1", "c3");
          //  chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlBarStacked;
            chartPage.ChartArea.Width = 800;
            var Xaxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
            var Xvalue = chartPage.Axes(Excel.XlAxisType.xlValue);
            Xaxis.ReversePlotOrder = true;
            DateTime min = DateTime.Today.AddDays(-30);
            DateTime max = DateTime.Today.AddDays(30);
            Xvalue.MinimumScale = min.ToOADate();
            Xvalue.MaximumScale = max.ToOADate();
            var series1 = (Excel.SeriesCollection)chartPage.SeriesCollection();
            var line1 = series1.NewSeries();
            line1.Name = "Veriliş Tarihi";
            line1.Values = xlWorkSheet.get_Range("b2", "b"+ (kayitsayisi + 1).ToString());
            line1.XValues = xlWorkSheet.get_Range("A2", "A"+ (kayitsayisi + 1).ToString());
            line1.Interior.ColorIndex = 0;
           var series2 = (Excel.SeriesCollection)chartPage.SeriesCollection();
            var line2 = series2.NewSeries();
            line2.Name = "İşin Yapılma Aralığı";
            line2.Values = xlWorkSheet.get_Range("c2", "c"+(kayitsayisi+1).ToString());
          //  line2.XValues = xlWorkSheet.get_Range("b2", "b3");

            //add data
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Veriliş Tarihi";
            xlWorkSheet.Cells[1, 3] = "Gün Sayısı";
            for (int i = 0; i < kayitsayisi; i++)
            {
            ilktarih = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);
            digertarih = Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
            xlWorkSheet.Cells[2+i, 1] = dataGridView1.Rows[i].Cells[4].Value.ToString();
            xlWorkSheet.Cells[2+i, 2] = dataGridView1.Rows[i].Cells[1].Value;
            xlWorkSheet.Cells[2+i, 3] = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value).Subtract(Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value)).TotalDays.ToString();
            }


                xlWorkSheet.Columns.AutoFit();
                xlWorkSheet.Rows.AutoFit();
                xlWorkBook.SaveAs(saveFileDialog1.FileName + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("Grafik Oluşturuldu ");

            }

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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            if (textBox3.Text == "")
            {
                button5.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button5.Enabled = true;
                button2.Enabled = false;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
            {
                MessageBox.Show("Dolu olan bir satır seçilmelidir !");
            }
            else
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if (textBox3.Text == "")
                {
                    button5.Enabled = false;
                    button2.Enabled = true;
                }
                else
                {
                    button5.Enabled = true;
                    button2.Enabled = false;
                }
            }
        }

        private void sayaci_durumu_Load(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                button5.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button5.Enabled = true;
                button2.Enabled = false;
            }
        }
    }
}
