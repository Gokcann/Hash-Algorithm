using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashAlgorithm
{
    class Converter
    {
        //password ve salt degerlerimiz privite oldugu icin get set yazıyoruz.
        private string password;
        public string Password
        {
            get{
                return password;
            }

            set{
                password = value;
            }
        }

        private string salt;
        public string Salt
        {
            get {
                return salt;
            }
            set {
                salt = value;
            }
        }
        //sting ifadeyi ASCII degerine donustuyoruz.
        public string ASCIIConverter() {
            byte[] ascii_converted = Encoding.ASCII.GetBytes(password);
            return BinaryConverter(ascii_converted);
        }
        //byte dizisindeki sayi degerlerini binary olarak ceviriyoruz, padleft kısmı 8 haneli olması icin en basa bir tane sifir ekliyor.
        public string BinaryConverter(byte[] data) {
            return string.Join("", data.Select(s => Convert.ToString(s, 2).PadLeft(8, '0')));
        }
        //hexadecimal ifadeyi binary olarak ceviriyor.
        public string HexConverter(string data)
        {
            string binary_converted;
            int hex = Convert.ToInt32(data, 16);
            binary_converted = Convert.ToString(hex, 2).PadLeft(8, '0');

            return binary_converted;
        }
        //binary ifadeyi stringe donusturuyor.
        public string BinaryStringConverter(string data)
        {
           
            List<Byte> bytelist = new List<Byte>();

            bytelist.Add(Convert.ToByte(data, 2));

            return Encoding.ASCII.GetString(bytelist.ToArray());

        }
        //string ifadeyi hexadecimal olarak ceviriyor.
        public string StringHexConverter(string data)
        {
            string hex = "";
            if (Convert.ToInt32(data, 2) < 16)
                hex += "0";
            hex += Convert.ToInt32(data, 2).ToString("X");

            return hex;
        }
    }
}
