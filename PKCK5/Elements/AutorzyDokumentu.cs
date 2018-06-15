using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("autorzy_dokumentu", Namespace = "http://www.example.org/types")]
    public partial class AutorzyDokumentu
    {
        [XmlElement("autor_dokumentu", Namespace = "http://www.example.org/types")]
        public List<AutorDokumentu> AutorDokumentuList { get; set; }

    }
}
