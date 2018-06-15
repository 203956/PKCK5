using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("dany_dział", Namespace = "http://www.example.org/types")]
    public partial class DanyDzial
    {
        [XmlAttribute("id_działu")]
        public string Id { get; set; }
        [XmlElement("książki", Namespace = "http://www.example.org/types")]
        public Ksiazki Ksiazki { get; set; }
    }
}
