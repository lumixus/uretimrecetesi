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

        public DataTable searchKesimID(string kid)
        {
            var veriler = new OleDbDataAdapter("select * from kesim", con);

            if (kid != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM kesim WHERE kesim_id =" + Convert.ToInt32(kid), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "kesim");
            return verikumesi.Tables["kesim"];
        }
        public DataTable selectKesim()
        {
            var veriler = new OleDbDataAdapter("select * from kesim", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "kesim");
            return verikumesi.Tables["kesim"];
        }
        public DataTable searchKesilenMal(string kmal)
        {
            var veriler = new OleDbDataAdapter("select * from kesim", con);

            if (kmal != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM kesim WHERE kesilen_malzeme LIKE '%" + kmal + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "kesim");
            return verikumesi.Tables["kesim"];
        }
        public void insertKesim(DateTime ktar, string kmal, string kmik, DateTime svertar)
        {

            cmd.CommandText = "INSERT INTO kesim (kesim_tar,kesilen_malzeme,kesilen_miktar,sayaciya_verilen_tar) values (@ktari,@kmalz,@kmiktar,@svertari)";
            cmd.Parameters.AddWithValue("@ktari", ktar);
            cmd.Parameters.AddWithValue("@kmalz", kmal);
            cmd.Parameters.AddWithValue("@kmiktar", kmik);
            cmd.Parameters.AddWithValue("@svertari", svertar);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kesim Eklendi");
        }
        public void deleteKesim(int kid)
        {
            cmd.CommandText = "DELETE FROM kesim WHERE kesim_id = @id";
            cmd.Parameters.AddWithValue("@id", kid);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        public DataTable searchSevkiyatID(string sid)
        {
            var veriler = new OleDbDataAdapter("select * from sevkiyat_malzeme", con);

            if (sid != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sevkiyat_malzeme WHERE malzeme_id =" + Convert.ToInt32(sid), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sevkiyat_malzeme");
            return verikumesi.Tables["sevkiyat_malzeme"];
        }
        public DataTable selectSevkiyat()
        {
            var veriler = new OleDbDataAdapter("select * from sevkiyat_malzeme", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sevkiyat_malzeme");
            return verikumesi.Tables["sevkiyat_malzeme"];
        }
        public DataTable searchSevkiyatMalzemeAdi(string smal)
        {
            var veriler = new OleDbDataAdapter("select * from sevkiyat_malzeme", con);

            if (smal != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sevkiyat_malzeme WHERE malzeme_adi LIKE '%" + smal + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "sevkiyat_malzeme");
            return verikumesi.Tables["sevkiyat_malzeme"];
        }
        public void insertSevkiyat(string smal, string smalmik)
        {

            cmd.CommandText = "INSERT INTO sevkiyat_malzeme (malzeme_adi,malzeme_miktar) values (@smaladi,@smalmiktar)";
            cmd.Parameters.AddWithValue("@smaladi", smal);
            cmd.Parameters.AddWithValue("@smalmiktar", smalmik);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sevkiyat Malzemesi Eklendi");
        }
        public void deleteSevkiyat(int sid)
        {
            cmd.CommandText = "DELETE FROM sevkiyat_malzeme WHERE malzeme_id = @id";
            cmd.Parameters.AddWithValue("@id", sid);
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
        public void deleteSayaci(int kid)
        {
            cmd.CommandText = "DELETE FROM sayaci WHERE sayaci_id = @id";
            cmd.Parameters.AddWithValue("@id", kid);
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
        public DataTable searchverilis_tar(string vertar)
        {
            var veriler = new OleDbDataAdapter("select * from sayaci", con);

            if (vertar != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sayaci WHERE verilis_tar LIKE '%" + vertar + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "verilis_tar");
            return verikumesi.Tables["verilis_tar"];
        }
        public DataTable searchyapilan_urun(string urun)
        {
            var veriler = new OleDbDataAdapter("select * from sayaci", con);

            if (urun != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM sayaci WHERE yapilan_urun LIKE '%" + urun + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "yapilan_urun");
            return verikumesi.Tables["yapilan_urun"];
        }
        public void insertsayaci(DateTime vertar, DateTime geltar, string urun)
        {

            cmd.CommandText = "INSERT INTO sayaci (verilis_tar,gelis_tar,yapilan_urun) values (@vertar,@geltar,@urun)";
            cmd.Parameters.AddWithValue("@vertar", vertar);
            cmd.Parameters.AddWithValue("@geltar", geltar);
            cmd.Parameters.AddWithValue("@tc", urun);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sayacı Eklendi");
        }
        public void insertUretimSemasi(string uretimadi, float sunnideri, float deri,float bagcik,float ilac,float salpa, float taban)
        {
            cmd.CommandText = "INSERT INTO uretim (uretilecek_urun,sunnideri,deri,bagcik,ilac,salpa,taban) values (@uretimadi,@sunnideri,@deri,@bagcik,@ilac,@salpa,@taban)";
            cmd.Parameters.AddWithValue("@uretimadi",uretimadi);
            cmd.Parameters.AddWithValue("@sunnideri", sunnideri);
            cmd.Parameters.AddWithValue("@deri", deri);
            cmd.Parameters.AddWithValue("@bagcik", bagcik);
            cmd.Parameters.AddWithValue("@ilac", ilac);
            cmd.Parameters.AddWithValue("@salpa", salpa);
            cmd.Parameters.AddWithValue("@taban", taban);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Üretim Şeması Eklendi");
        }
        public void deleteUretimsemasi(int id)
        {
            cmd.CommandText = "DELETE FROM uretim WHERE uretim_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        public DataTable select_uretimsemasi()
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchUretilecekurun(string urun)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (urun != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE uretilecek_urun LIKE '%" + urun + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretilecek_urun");
            return verikumesi.Tables["uretilecek_urun"];
        }
        public DataTable searchuretimID(string id)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (id != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE uretim_id =" + Convert.ToInt32(id), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchSunnideri(string sunniD)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (sunniD != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE sunnideri =" + Convert.ToInt32(sunniD), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchDeri(string deri)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (deri != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE deri =" + Convert.ToInt32(deri), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchBagcik(string bagcik)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (bagcik != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE bagcik =" + Convert.ToInt32(bagcik), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchİlac(string ilac)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (ilac != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE ilac =" + Convert.ToInt32(ilac), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchSalpa(string salpa)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (salpa != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE salpa =" + Convert.ToInt32(salpa), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
        public DataTable searchTaban(string taban)
        {
            var veriler = new OleDbDataAdapter("select * from uretim", con);

            if (taban != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM uretim WHERE taban =" + Convert.ToInt32(taban), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "uretim");
            return verikumesi.Tables["uretim"];
        }
    }
}
