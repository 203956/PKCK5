using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("dokument", Namespace = "http://www.example.org/types")]
    public partial class Dokument
    {
        [XmlElement("nagłówek", Namespace = "http://www.example.org/types")]
        public Naglowek Naglowek { get; set; }

        [XmlElement("biblioteka", Namespace = "http://www.example.org/types")]
        public Biblioteka Biblioteka { get; set; }
    }
}
