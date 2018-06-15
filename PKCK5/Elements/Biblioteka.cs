using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("biblioteka", Namespace = "http://www.example.org/types")]
    public partial class Biblioteka
    {
        [XmlElement("nazwa", Namespace = "http://www.example.org/types")]
        public string Nazwa { get; set; }

        [XmlElement("adres", Namespace = "http://www.example.org/types")]
        public Adres Adres { get; set; }

        [XmlElement("działy", Namespace = "http://www.example.org/types")]
        public Dzialy Dzialy { get; set; }

        [XmlElement("dany_dział", Namespace = "http://www.example.org/types")]
        public List<DanyDzial> DanyDzialList { get; set; }

    }
}
