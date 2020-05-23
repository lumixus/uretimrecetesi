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

        public DataTable searchBulunanID(string Bid)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (Bid != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_id =" + Convert.ToInt32(Bid), con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }
        public DataTable selectBulunan()
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);
            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }

        public DataTable searchBulananadi(string adı)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (adı != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adi LIKE '%" + adı + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }

        public DataTable searchBulananmodel(string model)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (model != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE modeli LIKE '%" + model + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }


        public DataTable searchUrunFiyat(string UrunF)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (UrunF != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE birim_fiyat LIKE '%" + UrunF + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }
         
        public void insertBulunan(string UrunAd,string UrunModeli, string UrunF, string UrunM,string UrunN,string UrunR)
        {

            cmd.CommandText = "INSERT INTO bulunan_urunler (urun_adi,urun_adet,birim_fiyat,modeli,numara,rengi) values (@UrunAd,@UrunModel,@UrunF,@UrunM,@UrunN,@UrunR)";
            cmd.Parameters.AddWithValue("@UrunAD", UrunAd);
            cmd.Parameters.AddWithValue("@UrunModel", UrunModeli);
            cmd.Parameters.AddWithValue("@UrunF", UrunF);
            cmd.Parameters.AddWithValue("@UrunM", UrunM);
            cmd.Parameters.AddWithValue("@UrunN", UrunN);
            cmd.Parameters.AddWithValue("@UrunR", UrunR);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Urun Eklendi");
        }
        public void deleteBulunan(int kid)
        {
            cmd.CommandText = "DELETE FROM bulunan_urunler WHERE urun_id = @id";
            cmd.Parameters.AddWithValue("@id", kid);
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
        public void insertsayaci(DateTime vertar, DateTime geltar, string urun,string sayaciadi)
        {

            cmd.CommandText = "INSERT INTO sayaci (verilis_tar,gelis_tar,yapilan_urun,sayaci_adi) values (@vertar,@geltar,@urun,@sayaciadi)";
            cmd.Parameters.AddWithValue("@vertar", vertar);
            cmd.Parameters.AddWithValue("@geltar", geltar);
            cmd.Parameters.AddWithValue("@tc", urun);
            cmd.Parameters.AddWithValue("@sayaciadi", sayaciadi);
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
        public void UretimeEkle(int uretimSayisi,string uretilecekurun)
        {
            int deri, bagcik, salpa, taban, ilac, sunideri,gereklideri,gereklibagcik,gereklisalpa,gereklitaban,gerekliilac,gereklisunideri;
            cmd.Connection = con;
            cmd.CommandText = "SELECT ham_miktar FROM hammaddeler WHERE ham_adi = 'Deri'";
            cmd.ExecuteNonQuery();
            deri = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT ham_miktar FROM hammaddeler WHERE ham_adi = 'Bağcık'";
            cmd.ExecuteNonQuery();
            bagcik = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT ham_miktar FROM hammaddeler WHERE ham_adi = 'Salpa'";
            cmd.ExecuteNonQuery();
            salpa = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT ham_miktar FROM hammaddeler WHERE ham_adi = 'Taban'";
            cmd.ExecuteNonQuery();
            taban = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT ham_miktar FROM hammaddeler WHERE ham_adi = 'İlaç'";
            cmd.ExecuteNonQuery();
            ilac = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT ham_miktar FROM hammaddeler WHERE ham_adi = 'Suni Deri'";
            cmd.ExecuteNonQuery();
            sunideri = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT * FROM uretim WHERE uretilecek_urun=@uretilecekurun";
            cmd.Parameters.AddWithValue("@uretilecekurun", uretilecekurun);
            var reader = cmd.ExecuteReader();
            reader.Read();
    
           gereklideri = Convert.ToInt32(reader[3]);
             gereklibagcik = Convert.ToInt32(reader[4]);
             gereklisalpa = Convert.ToInt32(reader[6]);
             gereklitaban = Convert.ToInt32(reader[7]);
             gerekliilac = Convert.ToInt32(reader[5]);
             gereklisunideri = Convert.ToInt32(reader[2]);
            deri = deri - (gereklideri * uretimSayisi);
            bagcik = bagcik - (gereklibagcik * uretimSayisi);
            salpa = salpa - (gereklisalpa * uretimSayisi);
            taban = taban - (gereklitaban * uretimSayisi);
            ilac = ilac - (gerekliilac * uretimSayisi);
            sunideri = sunideri - (gereklisunideri * uretimSayisi);
            reader.Close();
            if (deri < 0 || bagcik < 0 || salpa  < 0 || taban < 0 || ilac  < 0 || sunideri < 0)
            {
                MessageBox.Show("Gerekli Hammadde Yok !");
            }
            else
            {
                cmd.CommandText = "UPDATE hammaddeler SET ham_miktar = "+deri +" WHERE ham_adi = 'Deri'";
              
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE hammaddeler SET ham_miktar = "+bagcik+" WHERE ham_adi = 'Bağcık'";
           
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE hammaddeler SET ham_miktar = "+salpa+ " WHERE ham_adi = 'Salpa'";
         
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE hammaddeler SET ham_miktar = "+ilac+" WHERE ham_adi = 'İlaç'";
           
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE hammaddeler SET ham_miktar = "+sunideri+" WHERE ham_adi = 'Suni Deri'";
           
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE hammaddeler SET ham_miktar = "+taban+" WHERE ham_adi = 'Taban'";
           
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO uretimdeolan (uretim_durumu,uretilen_urun,uretim_adedi) values ('Başlangıç','"+uretilecekurun+"','"+uretimSayisi+"')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Üretime Eklendi"); 
        }
        }
        public void UpdateSevkiyat(int id,string malzemeadi,string miktar)
        {
            cmd.CommandText = "UPDATE sevkiyat_malzeme SET malzeme_adi = @malzemeadi , malzeme_miktar = @malzememiktar WHERE malzeme_id ="+id;
           // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@malzemeadi", malzemeadi);
            cmd.Parameters.AddWithValue("@malzememiktar", miktar);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show(malzemeadi + " Güncellendi");

        }
        public void UpdateUretimSemasi(int id,string uretilecekurun, string sunideri,string deri,string bagcik,string ilac,string salpa,string taban)
        {
            cmd.CommandText = "UPDATE uretim SET uretilecek_urun = @uretilecekurun , sunnideri = @sunideri, deri = @deri, bagcik=@bagcik, ilac=@ilac,salpa=@salpa,taban=@taban WHERE uretim_id =" + id;
            // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@uretilecekurun", uretilecekurun);
            cmd.Parameters.AddWithValue("@sunideri", sunideri);
            cmd.Parameters.AddWithValue("@deri", deri);
            cmd.Parameters.AddWithValue("@bagcik", bagcik);
            cmd.Parameters.AddWithValue("@ilac", ilac);
            cmd.Parameters.AddWithValue("@salpa", salpa);
            cmd.Parameters.AddWithValue("@taban", taban);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show(uretilecekurun + " Güncellendi");
        }
        public void UpdateSayaciDurumu(int id, DateTime vertar, DateTime geltar, string yapurun, string versay)
        {
            cmd.CommandText = "UPDATE sayaci SET verilis_tar = @vertar , gelis_tar = @geltar, yapilan_urun = @yapurun, sayaci_adi=@versay WHERE sayaci_id =" + id;
            // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@vertar", vertar);
            cmd.Parameters.AddWithValue("@geltar", geltar);
            cmd.Parameters.AddWithValue("@yapurun", yapurun);
            cmd.Parameters.AddWithValue("@versay", versay);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show(yapurun + " Güncellendi");
        }
        public void UpdatePersonel(int id, string ad, string soyad, string tc, string tel, DateTime tar, string gorev, string mail,string cins)
        {
            cmd.CommandText = "UPDATE pers SET pers_adi = @ad , pers_soyadi = @soyad, pers_tc = @tc, pers_telno = @tel, pers_gorev_id = @gorev, is_bas_tar = @tar, cinsiyet = @cins, pers_mail = @mail WHERE pers_id =" + id;
            // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@soyad", soyad);
            cmd.Parameters.AddWithValue("@tc", tc);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@gorev", gorev);
            cmd.Parameters.AddWithValue("@tar", tar);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@cins", cins);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show(ad + " Güncellendi");
        }
        public void UpdateKesim(int id, DateTime kestar, string kesmaz, string kesmik, DateTime sayvertar)
        {
            cmd.CommandText = "UPDATE kesim SET kesim_tar = @kestar , kesilen_malzeme = @kesmaz, kesilen_miktar = @kesmik, sayaciya_verilen_tar = @sayvertar WHERE kesim_id =" + id;
            // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@kestar", kestar);
            cmd.Parameters.AddWithValue("@kesmaz", kesmaz);
            cmd.Parameters.AddWithValue("@kesmik", kesmik);
            cmd.Parameters.AddWithValue("@sayvertar", sayvertar);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Güncellendi " + id + "ID");
        }
        public void UpdateHammadde(int id, string adi, string miktar, DateTime altar, string minmiktar)
        {
            cmd.CommandText = "UPDATE hammaddeler SET ham_adi = @adi , ham_miktar = @miktar, alis_tar = @altar, min_miktar = @minmiktar WHERE ham_id =" + id;
            // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@adi", adi);
            cmd.Parameters.AddWithValue("@miktar", miktar);
            cmd.Parameters.AddWithValue("@altar", altar);
            cmd.Parameters.AddWithValue("@minmiktar", minmiktar);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show(adi + " Güncellendi");
        }
        public void UpdateBulunan(int id, string adi, string adet, string fiyat, string model,string numara,string renk)
        {
            cmd.CommandText = "UPDATE bulunan_urunler SET urun_adi = @adi , urun_adet = @adet, birim_fiyat = @fiyat, modeli = @model, numara = @numara, rengi = @renk  WHERE urun_id =" + id;
            // cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@adi", adi);
            cmd.Parameters.AddWithValue("@adet", adet);
            cmd.Parameters.AddWithValue("@fiyat", fiyat);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@numara", numara);
            cmd.Parameters.AddWithValue("@renk", renk);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show(adi + " Güncellendi");
        }
        public int GetUser(string kullaniciadi,string sifre)
        {
            cmd.CommandText = "SELECT count(*) FROM yoneticiler WHERE username = @username and password = @password";
            cmd.Parameters.AddWithValue("@username", kullaniciadi);
            cmd.Parameters.AddWithValue("@password", sifre);
            cmd.ExecuteNonQuery();
           return (int)cmd.ExecuteScalar();
        }
    }
}
