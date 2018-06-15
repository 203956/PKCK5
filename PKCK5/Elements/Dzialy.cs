using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("działy", Namespace = "http://www.example.org/types")]
    public partial class Dzialy
    {
        [XmlElement("dział", Namespace = "http://www.example.org/types")]
        public List<Dzial> DzialList { get; set; }

    }
}
