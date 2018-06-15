using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("autor", Namespace = "http://www.example.org/types")]
    public partial class Autor
    {
        [XmlAttribute("nazwa_autora")]
        public NazwaAutora NazwaAutora { get; set; }

    }
}
