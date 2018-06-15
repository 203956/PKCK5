using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("dział", Namespace = "http://www.example.org/types")]
    public partial class Dzial
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("nazwa_działu")]
        public NazwaDzialu NazwaDzialu { get; set; }
    }
}
