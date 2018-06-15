using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("autorzy", Namespace = "http://www.example.org/types")]
    public partial class Autorzy
    {
        [XmlElement("autor", Namespace = "http://www.example.org/types")]
        public List<Autor> AutorList { get; set; }

    }
}
