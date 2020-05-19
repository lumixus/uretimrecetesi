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





        public DataTable searchBulunanID(string bulunanid)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (bulunanid != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_id =" + Convert.ToInt32(bulunanid), con);
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

        public DataTable searchUrunAd(string UrunAd)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (UrunAd != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adet LIKE '%" + UrunAd + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }

        public DataTable searchUrunAdet(string UrunA)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (UrunA != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adet LIKE '%" + UrunA + "%'", con);
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
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adet LIKE '%" + UrunF + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }


        public DataTable searchUrunM(string UrunM)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (UrunM != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adet LIKE '%" + UrunM + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }
        public DataTable searchUrunN(string UrunN)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (UrunN != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adet LIKE '%" + UrunN + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }

        public DataTable searchUrunR(string UrunR)
        {
            var veriler = new OleDbDataAdapter("select * from bulunan_urunler", con);

            if (UrunR != "")
            {
                veriler = new OleDbDataAdapter("SELECT * FROM bulunan_urunler WHERE urun_adet LIKE '%" + UrunR + "%'", con);
            }

            var verikumesi = new DataSet();
            veriler.Fill(verikumesi, "bulunan_urunler");
            return verikumesi.Tables["bulunan_urunler"];
        }
        public void insertBulunan( string UrunAd,string UrunA, string UrunF, string UrunM,string UrunN,string UrunR)
        {

            cmd.CommandText = "INSERT INTO bulunan_urunler (urun_adi,urun_adet,birim_fiyat,modeli,numara,rengi) values (@UrunAd,@UrunA,@UrunF,@UrunM,@UrunN,@UrunR)";
            cmd.Parameters.AddWithValue("@UrunAD", UrunAd);
            cmd.Parameters.AddWithValue("@UrunA", UrunA);
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
    }
}
