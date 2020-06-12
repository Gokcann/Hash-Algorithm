using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashAlgorithm
{
    class DatabaseConnect
    {
        //access icin gerekli baglanti tanimlamalari yapiliyor
        public OleDbDataAdapter da;
        public OleDbCommand cmd;
        public DataSet ds;
        public OleDbConnection con;

        public void Connect()
        {
            try
            {
                //veritabani belirtiliyor
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=database.accdb");
                con.Open();
            }
            catch (Exception e)
            {

            }
        }

        public void Close()
        {
            con.Close();
        }
        //veritabanina kullanici ekleme islemi
        public string Add(string user, string password, string salt)
        {
            cmd = new OleDbCommand();

            //ilk once kisi var mi diye kontrol ediliyor bunun icin QuerySalt metodumuzu cagirip girilen kullanici adini gonderiyoruz
            //eger kullanici varsa o kisinin salt degerini donduruyor eger yoksa null donduruyor.
            string querySalt = QuerySalt(user);
            if (querySalt == "null")
            {
                cmd.Connection = con;
                cmd.CommandText = "insert into kullanicilar (users,hashcode,saltvalue) values ('" + user + "','" + password + "','" + salt + "')";
                cmd.ExecuteNonQuery();
                return "Eklendi !";
            }
            else
            {
                return "HATA !";
            }

        }

        public string QueryHash(string a)
        {
            //veritabanindan kullanicinin hash degerini karsilastirmak icin cekiyoruz
            string sorgu = "select hashcode from kullanicilar where users=" + "'" + a + "'";
            cmd = new OleDbCommand(sorgu, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            string sonuc;
            dr.Read();
            try
            {
                sonuc = dr["hashcode"].ToString();

            }
            catch (Exception e)
            {
                sonuc = "null";
            }

            dr.Close();

            return sonuc;
        }

        public string QuerySalt(string a)
        {
            //veritabanindan kisinin salt degerini cekiyoruz tekrar giris yapmak istediginde
            //random atanmis salt degerine ulasabilmek ve gerekli islemleri yapabilmek icin.
            string sorgu = "select saltvalue from kullanicilar where users=" + "'" + a + "'";
            cmd = new OleDbCommand(sorgu, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            string sonuc;
            dr.Read();
            try
            {
                sonuc = dr["saltvalue"].ToString();

            }
            catch (Exception e)
            {
                sonuc = "null";
            }
            dr.Close();

            return sonuc;

        }
    }
}
