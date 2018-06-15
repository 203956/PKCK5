using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK5.Elements
{
    [XmlRoot("autor_dokumentu", Namespace = "http://www.example.org/types")]
    public partial class AutorDokumentu
    {
        [XmlAttribute("indeks")]
        public int Indeks { get; set; }
    }
}
