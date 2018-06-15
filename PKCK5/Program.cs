using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Windows;
using PKCK5.Elements;

namespace PKCK5
{
    public class Program
    {
        public FileInfo XmlFile { get; set; }
        public FileInfo SchemaFile { get; set; }
        XmlSerializer Serializer { get; set; }

        public Program(string xmlFile, string schemaFile)
        {
            XmlFile = new FileInfo(xmlFile);
            SchemaFile = new FileInfo(schemaFile);
            Serializer = new XmlSerializer(typeof(Dokument));
        }

        public Dokument LoadData()
        {
            Dokument dokument = null;
            if (XmlFile.Exists)
            {
                using (TextReader textReader = new StreamReader(XmlFile.FullName))
                {
                    dokument = (Dokument)Serializer.Deserialize(textReader);
                    textReader.Close();
                }
            }
            else
            {
                throw new IOException();
            }

            return dokument;
        }

        public void SaveData(Dokument dokument)
        {
            if (XmlFile.Exists) XmlFile.Delete();

            Stream stream = new FileStream(XmlFile.FullName, FileMode.Create);
            Serializer.Serialize(stream, dokument);
            stream.Close();
        }

        public void SaveCopy(Dokument dokument)
        {
            FileInfo tmp = new FileInfo("temp.xml");

            if (tmp.Exists) tmp.Delete();

            Stream stream = new FileStream(tmp.FullName, FileMode.Create);
            Serializer.Serialize(stream, dokument);
            stream.Close();
        }

        public bool ValidateXmlSchema(Dokument dokument)
        {
            try
            {
                SaveCopy(dokument);

                XmlDocument xmld = new XmlDocument();
                string xmlText = File.ReadAllText("temp.xml");
                xmld.LoadXml(xmlText);
                xmld.Schemas.Add("http://www.example.org/types", SchemaFile.FullName);
                xmld.Validate(ValidationCallBack);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            throw new Exception();
        }

    }
}

