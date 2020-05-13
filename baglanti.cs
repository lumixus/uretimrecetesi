using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

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

        public DataTable searchHammaddeID(string id)
        {
            var veriler = new OleDbDataAdapter("select * from hammaddeler", con);

           if(id != ""){ 
           veriler = new OleDbDataAdapter("SELECT * FROM hammaddeler WHERE ham_id =" + Convert.ToInt32(id), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "hammaddeler");
            return verikumesi.Tables["hammaddeler"];
        }
        public DataTable searchHammaddeAdi(string name)
        {
            var veriler = new OleDbDataAdapter("SELECT * FROM hammaddeler WHERE ham_adi LIKE '%"+name+"%'", con);
            if (name == "")
            {
                veriler = new OleDbDataAdapter("select * from hammaddeler", con);
            }
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "hammaddeler");
            return verikumesi.Tables["hammaddeler"];
        }
        public void insertHammadde(string hammaddeadi, float hammaddemiktar, int minmiktar, DateTime alistar)
        {
            cmd.CommandText = "INSERT INTO hammaddeler (ham_adi,ham_miktar,alis_tar,min_miktar) values (@hammaddeadi,@hammaddemiktar,@alistar,@minmiktar)";
            cmd.Parameters.AddWithValue("@hammaddeadi", hammaddeadi);
            cmd.Parameters.AddWithValue("@hammaddemiktar", hammaddemiktar);
            cmd.Parameters.AddWithValue("@alistar", alistar);
            cmd.Parameters.AddWithValue("@minmiktar", minmiktar);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Hammadde Eklendi");
        }
        public void deleteHammadde(int id)
        {
            cmd.CommandText = "DELETE FROM hammaddeler WHERE ham_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }


        public DataTable searchpersonelID(string id)
        {
            var veriler = new OleDbDataAdapter("select * from pers", con);

            if (id != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM pers WHERE pers_id =" + Convert.ToInt32(id), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "pers");
            return verikumesi.Tables["pers"];
        }
        public DataTable selectPersonel()
        {
            var veriler = new OleDbDataAdapter("select * from pers", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "pers");
            return verikumesi.Tables["pers"];
        }
        public DataTable searchPersonelAdi(string ad)
        {
            var veriler = new OleDbDataAdapter("select * from pers", con);

            if (ad != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM pers WHERE pers_adi LIKE '%"+ad +"%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "pers");
            return verikumesi.Tables["pers"];
        }
        public DataTable searchPersonelSoyadi(string soyad)
        {
            var veriler = new OleDbDataAdapter("select * from pers", con);

            if (soyad != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM pers WHERE pers_soyadi LIKE '%"+soyad+"%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "pers");
            return verikumesi.Tables["pers"];
        }
        public DataTable searchPersoneltc(string tc)
        {
            var veriler = new OleDbDataAdapter("select * from pers", con);

            if (tc != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM pers WHERE pers_tc = '"+tc+"'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "pers");
            return verikumesi.Tables["pers"];
        }
        public void insertPersonel(string ad, string soyad, string tc, string tel,DateTime isbas,string gorev,string mail,string cinsiyet)
        {
     
          cmd.CommandText = "INSERT INTO pers (pers_adi,pers_soyadi,pers_tc,pers_telno,pers_gorev_id,is_bas_tar,cinsiyet,pers_mail) values (@adi,@soyadi,@tc,@tel,@gorevid,@isbas,@cinsiyet,@mail)";
            cmd.Parameters.AddWithValue("@adi", ad);
            cmd.Parameters.AddWithValue("@soyadi", soyad);
            cmd.Parameters.AddWithValue("@tc", tc);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@gorevid", gorev);
            cmd.Parameters.AddWithValue("@isbas", isbas);
            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi");
        }
        public void deletePersonel(int id)
        {
            cmd.CommandText = "DELETE FROM pers WHERE pers_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        public DataTable select_sayaci()
        {
            var veriler = new OleDbDataAdapter("select * from sayaci", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sayaci");
            return verikumesi.Tables["sayaci"];
        }
        public void deleteSayaci(int id)
        {
            cmd.CommandText = "DELETE FROM sayaci WHERE sayaci_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        public DataTable searchsayaciID(string id)
        {
            var veriler = new OleDbDataAdapter("select * from sayaci", con);

            if (id != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sayaci WHERE sayaci_id =" + Convert.ToInt32(id), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sayaci");
            return verikumesi.Tables["sayaci"];
        }
        public DataTable searchverilis_tar(string verilis_tar)
        {
            var veriler = new OleDbDataAdapter("select * from sayaci", con);

            if (verilis_tar != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sayaci WHERE verilis_tar LIKE '%" + verilis_tar + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sayaci");
            return verikumesi.Tables["sayaci"];
        }
        public DataTable searchyapilan_urun(string yapilan_urun)
        {
            var veriler = new OleDbDataAdapter("select * from sayaci", con);

            if (yapilan_urun != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sayaci WHERE yapilan_urun LIKE '%" + yapilan_urun + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sayaci");
            return verikumesi.Tables["sayaci"];
        }
        public void insertsayaci(string urun, DateTime vertar, DateTime geltar)
        {

            cmd.CommandText = "INSERT INTO sayaci (verilis_tar,gelis_tar,yapilan_urun) values (@vertar,@geltar,@urun)";
            cmd.Parameters.AddWithValue("@vertar", vertar);
            cmd.Parameters.AddWithValue("@geltar", geltar);
            cmd.Parameters.AddWithValue("@urun", urun);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi");
        }
    }
}
