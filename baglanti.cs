using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace uretimrecetesi
{
    public  class baglanti
    {
       static OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = uretimrecetesi.accdb");
        OleDbCommand cmd = con.CreateCommand();
        public void baglandimi()
        {
            con.Open();
        }
        public DataTable select_hammadde()
        {
            var veriler = new OleDbDataAdapter("SELECT ham_adi,ham_miktar,alis_tar,min_miktar FROM hammaddeler", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "hammaddeler");
            return verikumesi.Tables["hammaddeler"];
 
        }
        public void baglantikapat() {
            con.Close();
        }
        public int personel_sayisi() {
            cmd.CommandText = "SELECT count(*) FROM pers";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            var sayi = cmd.ExecuteScalar();
            return (int)sayi;
        }
        public DataTable select_gunceluretim()
        {
            var veriler = new OleDbDataAdapter("SELECT * FROM uretimdeolan", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretimdeolan");
            return verikumesi.Tables["uretimdeolan"];
        }

        public DataTable select_bulunan_urunler()
        {
            var veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }

        public DataTable select_uretim()
        {
            var veriler = new OleDbDataAdapter("SELECT * FROM uretim", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable select_stoklariazalanlar()
        {
            var veriler = new OleDbDataAdapter("SELECT ham_adi,ham_miktar,min_miktar FROM hammaddeler WHERE ham_miktar <= min_miktar", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "hammaddeler");
            return verikumesi.Tables["hammaddeler"];
        }
        public DataTable select_hammaddeler()
        {
            var veriler = new OleDbDataAdapter("SELECT * FROM hammaddeler", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "hammaddeler");
            return verikumesi.Tables["hammaddeler"];
        }
        public OleDbDataReader select_hammaddeAlanlari()
        {
            cmd.CommandText = "SELECT * FROM hammaddeler";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            var alanlar = cmd.ExecuteReader();
            return alanlar;
        }

    }
}
