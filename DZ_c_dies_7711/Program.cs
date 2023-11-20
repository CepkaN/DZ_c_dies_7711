using System;
using System.IO;
using System.Text;

namespace DZ_c_dies_7711
{
    internal class Program
    {
        public static string str1 = "C:\\Users\\User\\Desktop\\C#\\DZ_c_dies_7711\\DZ_c_dies_7711\\mmm1.txt";
        public static string str2 = "C:\\Users\\User\\Desktop\\C#\\DZ_c_dies_7711\\DZ_c_dies_7711\\j.json";
        public static string str3 = "C:\\Users\\User\\Desktop\\C#\\DZ_c_dies_7711\\DZ_c_dies_7711\\t.txt";
        public static string str4 = "C:\\Users\\User\\Desktop\\C#\\DZ_c_dies_7711\\DZ_c_dies_7711\\xml.xml";
        public static string LISTA1;
        async static public void VVV()
        {
            using (FileStream fstream = File.OpenRead(str1))
            {
                byte[] buffer = new byte[fstream.Length];
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                //Console.WriteLine(textFromFile);
                LISTA1 = textFromFile;
            }
        }
        static void Main(string[] args)
        {
            VVV();
            DataTransfer DT=new DataTransfer();
            DT.JSON(str2, LISTA1);
            DT.TXT(str3, LISTA1);
            DT.XML(str4, LISTA1);
            DT.LisJSON(str2);
            DT.LisTXT(str3);
            DT.LisXML(str4);
        }
    }
}