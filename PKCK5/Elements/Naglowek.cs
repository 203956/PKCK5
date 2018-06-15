using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("nagłówek", Namespace = "http://www.example.org/types")]
    public partial class Naglowek
    {
        [XmlElement("opis", Namespace = "http://www.example.org/types")]
        public string Opis { get; set; }

        [XmlElement("autorzy_dokumentu", Namespace = "http://www.example.org/types")]
        public AutorzyDokumentu AutorzyDokumentu { get; set; }
    }
}
