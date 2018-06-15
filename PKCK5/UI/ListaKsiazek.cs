using PKCK5.Elements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace PKCK5.UI
{
    public class ListaKsiazek
    {
        public ObservableCollection<DanaKsiazka> ListaWszystkichKsiazek { get; set; }
        public ListaKsiazek(Dokument dokument)
        {
            ListaWszystkichKsiazek = new ObservableCollection<DanaKsiazka>();

            foreach (var danyDzial in dokument.Biblioteka.DanyDzialList)
            {
                foreach (var danaKsiazka in danyDzial.Ksiazki.KsiazkaList)
                {
                    ListaWszystkichKsiazek.Add(new DanaKsiazka()
                    {
                        Id = danaKsiazka.Id,
                        Tytul = danaKsiazka.Tytul,
                        Autorzy = DaniAutorzy(danaKsiazka.Autorzy.AutorList),
                        IloscStron = danaKsiazka.IloscStron,
                        DataWydania = DanaDataWydania(danaKsiazka.DataWydania)
                    });
                }
            }
        }
        public string DaniAutorzy(List<Autor> daniAutorzy)
        {
            string autorzyStr = String.Empty;
            List<string> autorzyList = new List<string>();
            foreach (var da in daniAutorzy)
            {
                autorzyList.Add(da.NazwaAutora.ToString().Replace("_", " "));
            }
            autorzyStr = String.Join(", ", autorzyList.ToArray());
            return autorzyStr;
        }

        public string DanaDataWydania(DataWydania dataWydania)
        {
            string dataStr = String.Empty;
            List<string> dataList = new List<string>
            {
                dataWydania.Dzien.ToString(),
                dataWydania.Miesiac.ToString(),
                dataWydania.Rok.ToString()
            };
            dataStr = String.Join("-", dataList.ToArray());
            return dataStr;
        }
    }
}