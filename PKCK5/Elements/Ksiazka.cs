using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("książka", Namespace = "http://www.example.org/types")]
    public partial class Ksiazka
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("tytuł", Namespace = "http://www.example.org/types")]
        public string Tytul { get; set; }

        [XmlElement("autorzy", Namespace = "http://www.example.org/types")]
        public Autorzy Autorzy { get; set; }

        [XmlElement("ilość_stron", Namespace = "http://www.example.org/types")]
        public int IloscStron { get; set; }

        [XmlElement("data_wydania", Namespace = "http://www.example.org/types")]
        public DataWydania DataWydania { get; set; }

    }
}
