using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DZ_c_dies_7711
{
    public delegate string DDD();
    public class DataTransfer
    {
        public event DDD DataSent;
        public event DDD DataReceived;

        public void OuEstText(string str)
        {
            var f = System.IO.File.ReadAllText(str);
            DataSent?.Invoke();
            Console.WriteLine(" отправлено ");

            if (f.Length != 0)
            {
                DataReceived?.Invoke();
                Console.WriteLine(" файл получен ");
            }
        }
        public void JSON(string str, string LISTA1)
        {
            string json = JsonConvert.SerializeObject(LISTA1);

            System.IO.File.WriteAllText(str, json);
            OuEstText(str);
        }
        public void XML(string str, string LISTA1)
        {
            XmlSerializer xml = new XmlSerializer(typeof(string));
            using (FileStream fstream = new FileStream(str, FileMode.OpenOrCreate))
            {
                xml.Serialize(fstream, LISTA1);
            }
            OuEstText(str);
        }

        public void TXT(string str2, string LISTA1)
        {
            using (StreamWriter vrrr = new StreamWriter(str2, false))
            {
                    StringBuilder strB = new StringBuilder();
                    for (int j = 0; j < LISTA1.Length; j++)
                    {
                        strB.Append(LISTA1[j]);
                    }
                    vrrr.WriteLine(strB.ToString());
            }
            OuEstText(str2);
        }

        public void LisJSON(string str)
        {
            string json = System.IO.File.ReadAllText(str);
            Console.WriteLine(JsonConvert.DeserializeObject(json));
        }

        public void LisXML(string str)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));
            using (FileStream fs = new FileStream(str, FileMode.OpenOrCreate))
            {
                var XML = xmlSerializer.Deserialize(fs);
                Console.WriteLine(XML);
            }

        }

        public void LisTXT(string str)
        {
            Console.WriteLine(System.IO.File.ReadAllText(str));
        }
    }
}
