using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Converter convert = new Converter();
        Encryption encryption = new Encryption();
        DatabaseConnect dbConnect = new DatabaseConnect();


        private void kayit_Click(object sender, EventArgs e)
        {
            convert = new Converter();
            encryption = new Encryption();
            dbConnect = new DatabaseConnect();
            //textbox a girilen sifreyi encryption sinifindaki Password degiskenine esitliyor
            encryption.Password = sifre.Text;
            //Encrypt islemi baslatiliyor
            encryption.Encrypt();
            string user = kullanici.Text;
            string state;
            dbConnect.Connect();
            //girilen bilgileri veritabanina ekliyor
            state = dbConnect.Add(user, encryption.hexrs, encryption.saltresult);
            dbConnect.Close();
            if (state == "HATA !")
                MessageBox.Show("HATA ");
            else
                MessageBox.Show("EKLENDİ");
        }

        private void giris_Click(object sender, EventArgs e)
        {
            convert = new Converter();
            encryption = new Encryption();
            dbConnect = new DatabaseConnect();
            string password, salt;
            dbConnect.Connect();
            password = dbConnect.QueryHash(kullanici.Text);
            salt = dbConnect.QuerySalt(kullanici.Text);
            dbConnect.Close();
            //eger girilen kullanici adi veritabaninda yoksa hata mesaji veriyor
            if (password == "null" || salt == "null")
            {
                MessageBox.Show("Kullanici Yok");
            }
            else
            {
                encryption.Password = sifre.Text;
                encryption.saltresult = salt;
                encryption.Encrypt2();
                //eger veritabanindaki hash kodu algoritmanin cikardigi sonucla ayniysa  giris yapildi uyarisi veriyor
                if (password == encryption.hexrs)
                {
                    MessageBox.Show("GIRIS YAPILDI");
                }
                else
                {
                    MessageBox.Show("HATA !!!");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            {
                //checkBox işaretli ise
                if (checkBox1.Checked)
                {
                    //karakteri göster.
                    sifre.PasswordChar = '\0';
                }
                //değilse karakterlerin yerine * koy.
                else
                {
                    sifre.PasswordChar = '*';
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }
    }
}
