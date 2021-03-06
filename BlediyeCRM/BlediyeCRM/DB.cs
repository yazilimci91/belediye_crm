﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlediyeCRM
{
    public class DB
    {
        //bağlantı
        public string ConnectionBelediye()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionBelediye"].ConnectionString;
            return conString;
        }

        //KullaniciGirisi
        public SqlDataReader KullaniciGirisi(string kadi, string sifre)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());

                cmd = new SqlCommand("select * from KULLANICILAR WHERE KADI='" + kadi + "' and SIFRE='" + sifre + "'", con);

                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();

            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Il  Getir
        public SqlDataReader IlGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("  SELECT IL FROM [BELEDIYE_CRM].[dbo].[BELEDIYE]  GROUP by IL order by IL ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }
         
        //Kullanıcı  Getir
        public SqlDataReader KullaniciGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("  SELECT ADSOYAD FROM [BELEDIYE_CRM].[dbo].[KULLANICILAR]  GROUP by ADSOYAD order by ADSOYAD ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }
         
        //Ilce  Getir
        public SqlDataReader IlceGetir(string IL)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("SELECT ILCE FROM [BELEDIYE_CRM].[dbo].[BELEDIYE] WHERE IL IN(SELECT IL FROM [BELEDIYE_CRM].[dbo].[BELEDIYE]  WHERE IL='" + IL + "'  GROUP by IL )order by IL", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Belediye Türü Getir
        public SqlDataReader BelediyeTuruGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BELDIYE_TURU  ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Belediye  Getir
        public SqlDataReader BelediyeGetir(string IL)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BELEDIYE where IL='" + IL + "'   order by KAYIT_ZAMANI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Belediye tüm  Getir
        public SqlDataReader BelediyeTumGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BELEDIYE  order by KAYIT_ZAMANI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //BelediyeID  Getir
        public SqlDataReader BelediyeGetirID(int BELEDIYE_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BELEDIYE where BELEDIYE_ID=" + BELEDIYE_ID, con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Belediye Sil
        public int BelediyeSil(int BELEDIYE_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());


                if (GorusmeSil(0, 0, BELEDIYE_ID) == 0)
                {
                    if (BirimSil(0, BELEDIYE_ID) == 0)
                    {
                        cmd = new SqlCommand("delete from BELEDIYE where BELEDIYE_ID=" + BELEDIYE_ID, con);
                        con.Open();
                        sonuc = cmd.ExecuteNonQuery();
                        con.Close();

                        return sonuc;
                    }
                    else
                        return sonuc;
                }
                else
                    return sonuc;

            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Görüşme Sil
        public int GorusmeSil(int GORUSME_ID, int BIRIM_ID, int BELEDIYE_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;

                con = new SqlConnection(ConnectionBelediye());
                if (BIRIM_ID == 0 & BELEDIYE_ID == 0)
                    cmd = new SqlCommand("delete from GORUSMELER where  GORUSME_ID=" + GORUSME_ID, con);
                else if (GORUSME_ID == 0 & BIRIM_ID == 0)
                    cmd = new SqlCommand("delete from GORUSMELER where  BELEDIYE_ID=" + BELEDIYE_ID, con);
                else if (GORUSME_ID == 0 & BELEDIYE_ID == 0)
                    cmd = new SqlCommand("delete from GORUSMELER where  BIRIM_ID=" + BIRIM_ID, con);
                con.Open();
                sonuc = cmd.ExecuteNonQuery();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Birim Sil
        public int BirimSil(int BIRIM_ID, int BELEDIYE_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                if (BELEDIYE_ID == 0)
                    cmd = new SqlCommand("delete from BIRIMLER where  BIRIM_ID=" + BIRIM_ID, con);
                else
                    cmd = new SqlCommand("delete from BIRIMLER where  BELEDIYE_ID=" + BELEDIYE_ID, con);
                con.Open();
                sonuc = cmd.ExecuteNonQuery();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Birimleri  Getir
        public SqlDataReader BirimleriGetir(int BELEDIYE_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BIRIMLER   where BELEDIYE_ID=" + BELEDIYE_ID + " order by KAYIT_ZAMANI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Birimleri Hepsi  Getir
        public SqlDataReader BirimleriGetirHespi()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BIRIMLER  order by KAYIT_ZAMANI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Görüşmeleri  Getir
        public SqlDataReader GorusmeleriGetir(int BIRIM_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from GORUSMELER where BIRIM_ID=" + BIRIM_ID + " order by KAYIT_ZAMANI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Görüşmeleri Hepsi  Getir
        public SqlDataReader GorusmeleriGetirHepsi()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from GORUSMELER  order by KAYIT_ZAMANI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Kullanıcları  Getir
        public SqlDataReader KullanicilariGetir(int KULLANICI_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                if (KULLANICI_ID == 0)
                    cmd = new SqlCommand("select * from KULLANICILAR where   YETKI=2 OR YETKI=0   order by KULLANICI_ID desc ", con);
                else
                    cmd = new SqlCommand("select * from KULLANICILAR  where KULLANICI_ID= " + KULLANICI_ID + " and YETKI=1 and YETKI=0", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Birim  Getir
        public SqlDataReader BirimGetir(int BIRIM_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BIRIMLER where BIRIM_ID=" + BIRIM_ID, con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Birimleri rapor  Getir
        public SqlDataReader BirimleriRaporla(int CBS, int numarataj, int tabela)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());

                if (numarataj == -1 & tabela == -1)
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS, con);
                else if (CBS == -1 && tabela == -1)
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where NUMARATAJ=" + numarataj, con);
                else if (CBS == -1 && numarataj == -1)
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where NUMARATAJ_TABELASI=" + tabela, con);
                else if (tabela == -1)
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS + "and NUMARATAJ=" + numarataj, con);
                else if (numarataj == -1)
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS + "and NUMARATAJ_TABELASI=" + tabela, con);
                else if (CBS == -1)
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID   where NUMARATAJ_TABELASI=" + tabela + "and NUMARATAJ=" + numarataj, con);
                else
                    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS + "and NUMARATAJ=" + numarataj + "and NUMARATAJ_TABELASI=" + tabela, con);

                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //GÖRÜŞME  Getir
        public SqlDataReader GorusmeGetir(int GORUSME_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from GORUSMELER where GORUSME_ID=" + GORUSME_ID, con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Kullanıcı Sil
        public int KullanicieSil(int KULLANICI_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());

                cmd = new SqlCommand("delete from KULLANICILAR where KULLANICI_ID=" + KULLANICI_ID, con);
                con.Open();
                sonuc = cmd.ExecuteNonQuery();
                con.Close();

                return sonuc;


            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Kullanıcı Sil
        public int SifreGuncelleme(int KULLANICI_ID, string sifre)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select SIFRE,KULLANICI_ID from KULLANICILAR where KULLANICI_ID=" + KULLANICI_ID + " and SIFRE='" + sifre + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = 0;

                }
                con.Close();


                return sonuc;


            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Kullanıcı  Getir
        public SqlDataReader KullaniciGetir(int KULLANICI_ID)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());

                cmd = new SqlCommand("select * from KULLANICILAR where KULLANICI_ID=" + KULLANICI_ID, con);

                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Beldiye sayısı
        public int BelediyeAdet()
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select count(*) as adet from BELEDIYE", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = Convert.ToInt32("" + dr["adet"]);
                }
                con.Close();
                return sonuc;
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Birim sayısı
        public int BirimAdet()
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select count(*) as adet from BIRIMLER", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = Convert.ToInt32("" + dr["adet"]);
                }
                con.Close();
                return sonuc;
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Görüşmeler sayısı
        public int GorusmeAdet()
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select count(*) as adet from GORUSMELER", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = Convert.ToInt32("" + dr["adet"]);
                }
                con.Close();
                return sonuc;
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        // BIRIM ID'YE GORE BELEDIYE_ID CEK
        public int BirimBelediyeID(int BIRIM_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from BIRIMLER where  BIRIM_ID=" + BIRIM_ID, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = Convert.ToInt32(dr["BELEDIYE_ID"]);

                }
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        // GORUSME ID'YE GORE BELEDIYE_ID CEK
        public int GorusmeBelediyeID(int GORUSME_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from GORUSMELER where  GORUSME_ID=" + GORUSME_ID, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = Convert.ToInt32(dr["BELEDIYE_ID"]);

                }
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        // GORUSME ID'YE GORE BIRIM_ID CEK
        public int GorusmeBirimID(int GORUSME_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from GORUSMELER where  GORUSME_ID=" + GORUSME_ID, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = Convert.ToInt32(dr["BIRIM_ID"]);

                }
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        // GORUSME ID'YE GORE DOSYA YOLU CEK
        public string GorusmeDOSYA_YOLU(int GORUSME_ID)
        {
            string sonuc = "";
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from GORUSMELER where  GORUSME_ID=" + GORUSME_ID, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    sonuc = "" + (dr["DOSYA_YOLU"]);

                }
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //SilinenGorusmeleriGetir  Getir
        public SqlDataReader SilinenGorusmeleriGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from SILINEN_GORUSMELER   order by SILME_TARIHI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Silinen Görüşme Sil
        public int SilinenGorusmeSil(int GORUSME_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("delete from SILINEN_GORUSMELER where  GORUSME_ID=" + GORUSME_ID, con);
                con.Open();
                sonuc = cmd.ExecuteNonQuery();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //SilinenBirimleriGetir  Getir
        public SqlDataReader SilinenBirimleriGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from SILINEN_BIRIMLER  order by SILME_TARIHI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Silinen bİRİM Sil
        public int SilinenBirimSil(int BIRIM_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("delete from SILINEN_BIRIMLER where  BIRIM_ID=" + BIRIM_ID, con);
                con.Open();
                sonuc = cmd.ExecuteNonQuery();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //SilinenBelediyelerGetir  Getir
        public SqlDataReader SilinenBelediyelerGetir()
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("select * from SILINEN_BELEDIYELER order by SILME_TARIHI desc ", con);
                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }

        //Silinen BELEDIYE  Sil
        public int SilinenBelediyeSil(int BELEDIYE_ID)
        {
            int sonuc = -1;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());
                cmd = new SqlCommand("delete from SILINEN_BELEDIYELER where  BELEDIYE_ID=" + BELEDIYE_ID, con);
                con.Open();
                sonuc = cmd.ExecuteNonQuery();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }


        //Görüşme raporla  Getir
        public SqlDataReader GorusmeleriRaporla(string basTar, string bitTar, string IL, string adsoyad)
        {
            SqlDataReader sonuc = null;
            try
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                con = new SqlConnection(ConnectionBelediye());

                if (IL == "IL_SECINIZ" && adsoyad == "KULLANICI_SEC")
                    cmd = new SqlCommand("select bel.IL, bel.ILCE, b.[GORUSME_KONUSU], b.KAYIT_ZAMANI, b.KULLANICI_ADI,b.SON_DURUMU from GORUSMELER b inner join BIRIMLER e on b.BIRIM_ID=e.BIRIM_ID inner join BELEDIYE bel on e.BELEDIYE_ID=bel.BELEDIYE_ID  where b.KAYIT_ZAMANI BETWEEN '" + basTar + "'  and  '" + bitTar + "'", con);
                //else if (CBS == -1 && tabela == -1)
                //    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where NUMARATAJ=" + numarataj, con);
                //else if (CBS == -1 && numarataj == -1)
                //    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where NUMARATAJ_TABELASI=" + tabela, con);
                //else if (tabela == -1)
                //    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS + "and NUMARATAJ=" + numarataj, con);
                //else if (numarataj == -1)
                //    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS + "and NUMARATAJ_TABELASI=" + tabela, con);
                //else if (CBS == -1)
                //    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID   where NUMARATAJ_TABELASI=" + tabela + "and NUMARATAJ=" + numarataj, con);
                //else
                //    cmd = new SqlCommand("select * from BIRIMLER b inner join BELEDIYE e on b.BELEDIYE_ID=e.BELEDIYE_ID  where CBS_YAZILIMI=" + CBS + "and NUMARATAJ=" + numarataj + "and NUMARATAJ_TABELASI=" + tabela, con);

                con.Open();
                sonuc = cmd.ExecuteReader();
                return sonuc;
                con.Close();
            }
            catch (Exception exception)
            {
                return sonuc;
                Console.Write("'{0}' ", String.IsNullOrEmpty("hata") ? "<>" : "hata olustu");
            }
        }


    }
}