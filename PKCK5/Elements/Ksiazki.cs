using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("książki", Namespace = "http://www.example.org/types")]
    public partial class Ksiazki
    {
        [XmlElement("książka", Namespace = "http://www.example.org/types")]
        public List<Ksiazka> KsiazkaList { get; set; }

    }
}
