using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.IO;

namespace ChuKyDienTu
{
    public class ChuKyDienTu
    {
       
        public void SaveKey(object obj, string fileName)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());

            TextWriter textWriter = new StreamWriter(fileName);
            sr.Serialize(textWriter, obj);
            textWriter.Close();
        }
        
        public long sntngaunhien()
        {
            Random random = new Random();
            long k = 2L;
            while (((k < 5L) || (k > 0x270fL)) || !ktnt(k))
            {
                k = random.Next(5, 0x270f);
            }
            return k;
        }

        public bool ktnt(long k)
        {
            if (k < 2L)
            {
                return false;
            }
            for (long i = 2L; i <= (k / 2L); i += 1L)
            {
                if ((k % i) == 0L)
                {
                    return false;
                }
            }
            return true;
        }

        public long max(long a, long b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }
        //hàm tính nghịch đảo
        public long nd(long a, long b)
        {
            long num2 = 1L;
            while ((((num2 * b) + 1L) % a) != 0L)
            {
                num2 += 1L;
            }
            return (((num2 * b) + 1L) / a);
        }

        public long ucln(long a, long b)
        {
            while (b != 0L)
            {
                long num2 = a % b;
                a = b;
                b = num2;
            }
            return a;
        }
        public string BamSHA(string mess)
        {
            SHA256Managed managed = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(mess);
            bytes = managed.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in bytes)
            {
                builder.Append(num.ToString("x2").ToLower());
            }
            return builder.ToString().ToUpper();
        }
    }
}
