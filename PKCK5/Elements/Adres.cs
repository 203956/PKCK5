using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("adres", Namespace = "http://www.example.org/types")]
    public partial class Adres
    {
        [XmlElement("ulica", Namespace = "http://www.example.org/types")]
        public string Ulica { get; set; }

        [XmlElement("numer", Namespace = "http://www.example.org/types")]
        public string Numer { get; set; }

        [XmlElement("miejscowość", Namespace = "http://www.example.org/types")]
        public string Miejscowosc { get; set; }

    }
}
