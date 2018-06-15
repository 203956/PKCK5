using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("data_wydania", Namespace = "http://www.example.org/types")]
    public partial class DataWydania
    {
        [XmlAttribute("dzień")]
        public string Dzien { get; set; }
        [XmlAttribute("miesiąc")]
        public string Miesiac { get; set; }
        [XmlAttribute("rok")]
        public string Rok { get; set; }

    }
}
