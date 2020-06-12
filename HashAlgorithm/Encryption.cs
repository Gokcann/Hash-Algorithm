using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashAlgorithm
{
    class Encryption
    {
        XorAndOr xor_and_or = new XorAndOr();
        Converter converter = new Converter();
        Random rand = new Random(DateTime.Now.Millisecond);

        //gerekli degiskenler olusturuluyor
        private string password;
        private string[] data = new string[36];
        public string salt;
        private int[] shift = { 3, 12, 1, 4, 5, 16, 11, 2, 13, 9, 10, 7, 15, 6, 10, 2, 7, 8, 1, 5, 11, 2, 13, 4, 5, 9, 10, 7, 2, 14, 12, 6, 1, 8, 2, 5 };
        public string result = "";
        public string result2 = "";
        public string result3 = "";
        public string result4 = "";
        public string result5 = "";
        public string hexresult = "";
        public string saltresult = "";
        public string hexrs = "";
        public string hexrs2 = "";

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        //giris isleminde calisan metod
        public void Encrypt2()
        {
            //textbox a girilen sifreyi alip ascii'ye cevriliyor
            converter.Password = password;
            password = converter.ASCIIConverter();
            //girilen sifre uzunluguna gore ne sonuna ne kadar sifir koyulacagina karar veriliyor
            int fill = 192 - password.Length;
            //"1" ekleyip geri kalanina sifir koyuluyor
            password += "1";
            Zero(fill);
            //xor/or/and islemleri yapmak icin 16 bitlik parcalara bolunuyor
            Section();
            //burada elimizde bulunan 12 adet 16 bitlik veriyi 36 ya cikariliyor
            Step2();
            //onceden belirlenen sayilara gore kaydirma islemi yapiliyor
            Shift();
            //36 adet 16 bitlik verimizi xor-and-or islemlerine tabi tutarak tekrar 12 adet 16 bitlik verilere indirgiyor
            Match();
            //salt sonucu hexadecimal haline cevriliyor
            for (int i = 0; i < 24; i++)
            {
                salt += converter.HexConverter(saltresult.Substring(i * 2, 2));
            }
            //sifrenin hashlenmis hali ile salt isleme giriyor
            Salt();
            //
            for (int i = 0; i < 24; i++)
            {
            //Salt() metodundan cikan degerler hex haline cevriliyor
                hexrs += converter.StringHexConverter(result4.Substring(i * 8, 8));
            }
        }

        public void Encrypt()
        {
            //textbox a girilen sifreyi alip ascii'ye cevriliyor
            converter.Password = password;
            password = converter.ASCIIConverter();
            //girilen sifre uzunluguna gore ne sonuna ne kadar sifir koyulacagina karar veriliyor
            int fill = 192 - (password.Length);
            //"1" ekleyip geri kalanina sifir koyuluyor
            password += "1";
            Zero(fill);
            //xor/or/and islemleri yapmak icin 16 bitlik parcalara bolunuyor
            Section();
            //burada elimizde bulunan 12 adet 16 bitlik veriyi 36 ya cikariliyor
            Step2();
            //onceden belirlenen sayilara gore kaydirma islemi yapiliyor
            Shift();
            //36 adet 16 bitlik verimizi xor-and-or islemlerine tabi tutarak tekrar 12 adet 16 bitlik verilere indirgiyor
            Match();
            //yeni kayitta, yeni bir salt degeri üretiliyor.
            for (int i = 0; i < 24; i++)
            {
                salt += NewSalt().Substring(0, 8);
            }
            //sifrenin hashlenmis hali ile salt isleme giriyor
            Salt();
            //Salt() metodundan cikan degerler hex haline cevriliyor
            for (int i = 0; i < 24; i++)
            {
                hexresult += converter.StringHexConverter(result2.Substring(i * 8, 8));
                hexrs += converter.StringHexConverter(result4.Substring(i * 8, 8));
                saltresult += converter.StringHexConverter(salt.Substring(i * 8, 8));
            }

        }
        //hash degeri ile salt degeri burada isleme giriyor
        private void Salt()
        {
            for (int i = 0; i < 192; i++)
                result4 += xor_and_or.XOR(result2.Substring(i, 1), salt.Substring(i, 1));
        }
        //yeni salt olusturma metodu
        private string NewSalt()
        {
            byte[] salt = BitConverter.GetBytes(rand.Next(32, 127));

            return converter.BinaryConverter(salt);
        }
        //[0+i,4+i,8+i] [12+i,16+i,20+i] [i+24,i+16,i+20] onceden belirlenen bu degerlere gore farkli islemlere gonderiliyorlar
        private void Match()
        {
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 16; j++)
                {
                    result2 += xor_and_or.XOR(xor_and_or.XOR(data[i].Substring(j, 1), data[i + 4].Substring(j, 1)),data[i+8].Substring(j,1));

                }

                for (int j = 0; j < 16; j++)
                {

                    result2 += xor_and_or.XOR(xor_and_or.AND(data[i + 12].Substring(j, 1), data[i + 16].Substring(j, 1)),data[i+20].Substring(j,1));


                }

                for (int j = 0; j < 16; j++)
                {
                    result2 += xor_and_or.XOR(xor_and_or.OR(data[i + 24].Substring(j, 1), data[i + 28].Substring(j, 1)),data[i+32].Substring(j,1));

                }
            }
        }
        //kalanin tamamini sifir yapmak icin kullanilan metod
        private void Zero(int data)
        {
            for (int i = 0; i < data - 1; i++)
            {
                password += "0";
            }
        }
        //kaydirma islemini gerceklestiren metod
        private void Shift()
        {
            for (int i = 0; i < 36; i++)
            {
                data[i] = data[i].Substring(shift[i], 16 - shift[i]) + data[i].Substring(0, shift[i]);
            }
        }
        //parcalara bolme islemini gerceklestiren metod
        private void Section()
        {
            for (int i = 0; i < 12; i++)
            {
                data[i] = password.Substring(i * 16, 16);
            }
        }
        //[i-1,i-4,i-7,i-11] onceden belirlenen formule gore Step3 metoduna yolluyor 
        private void Step2()
        {
            for (int i = 11; i < 35; i++)
            {
                data[i + 1] = Step3(data[i - 1], data[i - 4], data[i - 7], data[i - 11]);
            }
        }
        //gelen stringleri xor islemine gonderiyor
        private string Step3(string data1,string data2,string data3,string data4)
        {
            string result = "";
            for (int i = 0; i < 16; i++)
            {
                result += xor_and_or.XOR(xor_and_or.XOR(xor_and_or.XOR(data1.Substring(i, 1), data2.Substring(i, 1)), data3.Substring(i, 1)), data4.Substring(i, 1));
            }
            return result;
        }

    }
}
