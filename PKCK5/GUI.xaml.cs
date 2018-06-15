using PKCK5.Elements;
using PKCK5.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PKCK5
{
    /// <summary>
    /// Logika interakcji dla klasy GUI.xaml
    /// </summary>
    public partial class GUI : Window
    {
        public Dokument Dokument { get; set; }
        public Program Program { get; set; }
        public ListaKsiazek ListaKsiazek { get; set; }
        public GUI()
        {
            InitializeComponent();
            Dokument = new Dokument();
            Program = new Program("Resources//firstExercise.xml", "Resources//secondExercise.xsd");
            OpenApplication();
            this.ListaKsiazekListBox.DataContext = ListaKsiazek;
            this.Autor1Box.ItemsSource = Enum.GetValues(typeof(NazwaAutora)).Cast<NazwaAutora>();
            this.Autor2Box.ItemsSource = Enum.GetValues(typeof(NazwaAutora)).Cast<NazwaAutora>();
            this.Autor3Box.ItemsSource = Enum.GetValues(typeof(NazwaAutora)).Cast<NazwaAutora>();
            this.DziałBox.ItemsSource = Enum.GetValues(typeof(NazwaDzialu)).Cast<NazwaDzialu>();
            this.AutorDokumentu1Box.DataContext = Dokument.Naglowek.AutorzyDokumentu.AutorDokumentuList.First().Indeks;
            this.AutorDokumentu2Box.DataContext = Dokument.Naglowek.AutorzyDokumentu.AutorDokumentuList.Last().Indeks;
            this.NaglowekBox.DataContext = Dokument.Naglowek.Opis;
            this.BibliotekaNazwaBox.DataContext = Dokument.Biblioteka.Nazwa;
            this.BibliotekaAdresBox.DataContext = String.Concat(Dokument.Biblioteka.Adres.Ulica, " ", Dokument.Biblioteka.Adres.Numer, " ", Dokument.Biblioteka.Adres.Miejscowosc);
        }

        private void OpenApplication()
        {
            if (!Program.XmlFile.Exists)
            {
                MessageBox.Show("Plik " + Program.XmlFile.FullName.ToString() + " nie istnieje. \nDanych nie załadowano", "Wczytywanie danych");
            }
            else
            {
                Dokument = Program.LoadData();
                ListaKsiazek = new UI.ListaKsiazek(Dokument);
            }
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            Program.SaveData(Dokument);
            ListBox tmp = (ListBox)sender;
            DanaKsiazka dana = (DanaKsiazka)tmp.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć książkę " + dana.Tytul + "?", "Usuwanie", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                foreach(var dzial in Dokument.Biblioteka.DanyDzialList)
                {
                    dzial.Ksiazki.KsiazkaList.RemoveAll(x => x.Id.Equals(dana.Id));
                }
                if (Program.ValidateXmlSchema(Dokument))
                {
                    ListaKsiazek.ListaWszystkichKsiazek.Remove(dana);
                    Program.SaveData(Dokument);
                }
                else
                {
                    MessageBox.Show("Edycja danych niezgodna z XML Schema!", "Błąd!");
                    Dokument = Program.LoadData();
                }
            }
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {

            List<Autor> tempAutorList = new List<Autor>();
            char[] tempCharTable = null;
            string tempId = null;
            List<string> tempIdList = new List<string>();

            if (TytulBox.Text == String.Empty)
            {
                MessageBox.Show("Nie podano tytułu!", "Błąd!");
                return;
            }

            if (IloscStronBox.Text == String.Empty)
            {
                MessageBox.Show("Nie podano ilości stron książki!", "Błąd!");
                return;
            }

            int number;
            if (!int.TryParse(IloscStronBox.Text, out number))
            {
                MessageBox.Show("Ilości stron książki podano w złym formacie!", "Błąd!");
                return;
            }

            if (DataWydaniaBox.Text == String.Empty)
            {
                MessageBox.Show("Nie podano daty wydania książki!", "Błąd!");
                return;
            }

            tempCharTable = DataWydaniaBox.Text.ToCharArray();
            if (int.Parse(String.Concat(tempCharTable[6], tempCharTable[7], tempCharTable[8], tempCharTable[9])) < 1500 || int.Parse(String.Concat(tempCharTable[6], tempCharTable[7], tempCharTable[8], tempCharTable[9])) > 2018)
            {
                MessageBox.Show("Podano zły rok wydania książki!", "Błąd!");
                return;
            }

            if (int.Parse(String.Concat(tempCharTable[3], tempCharTable[4])) < 1 || int.Parse(String.Concat(tempCharTable[3], tempCharTable[4])) > 12)
            {
                MessageBox.Show("Podano zły miesiąc wydania książki!", "Błąd!");
                return;
            }

            if (int.Parse(String.Concat(tempCharTable[0], tempCharTable[1])) < 1 || int.Parse(String.Concat(tempCharTable[0], tempCharTable[1])) > 31)
            {
                MessageBox.Show("Podano zły dzień wydania książki!", "Błąd!");
                return;
            }

            if ((Autor1Box.Text == String.Empty && Autor2Box.Text == String.Empty && Autor3Box.Text == String.Empty) ||
                (Autor1Box.Text.Equals("Brak") && Autor2Box.Text.Equals("Brak") && Autor3Box.Text.Equals("Brak")) ||
                (Autor1Box.Text.Equals("Brak") && Autor2Box.Text.Equals("Brak") && Autor3Box.Text == String.Empty) ||
                (Autor1Box.Text.Equals("Brak") && Autor2Box.Text == String.Empty && Autor3Box.Text == String.Empty) ||
                (Autor1Box.Text == String.Empty && Autor2Box.Text.Equals("Brak") && Autor3Box.Text == String.Empty) ||
                (Autor1Box.Text == String.Empty && Autor2Box.Text == String.Empty && Autor3Box.Text.Equals("Brak")))
            {
                MessageBox.Show("Nie podano autora!", "Błąd!");
                return;
            }

            if (Autor1Box.Text.Equals("Brak") && Autor2Box.Text.Equals("Brak") && Autor3Box.Text.Equals("Brak"))
            {
                MessageBox.Show("Nie podano autora!", "Błąd!");
                return;
            }

            if (Autor1Box.Text.Equals("Brak") && Autor2Box.Text.Equals("Brak") && Autor3Box.Text == String.Empty)
            {
                MessageBox.Show("Nie podano autora!", "Błąd!");
                return;
            }

            if (Autor1Box.Text.Equals(Autor2Box.Text) && Autor1Box.Text != String.Empty)
            {
                MessageBox.Show("Podano kilka razy tego samego autora!", "Błąd!");
                return;
            }

            if (Autor1Box.Text.Equals(Autor3Box.Text) && Autor1Box.Text != String.Empty)
            {
                MessageBox.Show("Podano kilka razy tego samego autora!", "Błąd!");
                return;
            }

            if (Autor2Box.Text.Equals(Autor3Box.Text) && Autor2Box.Text != String.Empty)
            {
                MessageBox.Show("Podano kilka razy tego samego autora!", "Błąd!");
                return;
            }

            if (!Autor1Box.Text.Equals("Brak") && Autor1Box.Text != String.Empty)
            {
                tempAutorList.Add(new Autor()
                {
                    NazwaAutora = (NazwaAutora)Enum.Parse(typeof(NazwaAutora), Autor1Box.Text)
                });
            }

            if (!Autor2Box.Text.Equals("Brak") && Autor2Box.Text != String.Empty)
            {
                tempAutorList.Add(new Autor()
                {
                    NazwaAutora = (NazwaAutora)Enum.Parse(typeof(NazwaAutora), Autor2Box.Text)
                });
            }

            if (!Autor3Box.Text.Equals("Brak") && Autor3Box.Text != String.Empty)
            {
                tempAutorList.Add(new Autor()
                {
                    NazwaAutora = (NazwaAutora)Enum.Parse(typeof(NazwaAutora), Autor3Box.Text)
                });
            }

            if (DziałBox.Text == String.Empty)
            {
                MessageBox.Show("Nie podano działu książki!", "Błąd!");
                return;
            }

            foreach (var danyDzial in Dokument.Biblioteka.DanyDzialList)
            {
                foreach (var danaKsiazka in danyDzial.Ksiazki.KsiazkaList)
                {
                    tempIdList.Add(danaKsiazka.Id);
                }
            }
            tempIdList.Sort();
            tempId = tempIdList.Last();
            if(int.Parse(tempId).ToString().Count() == 3)
            {
                tempId = (int.Parse(tempId) + 1).ToString();
            }
            else if (int.Parse(tempId).ToString().Count() == 2)
            {
                tempId = String.Concat("0", (int.Parse(tempId) + 1).ToString());
            }
            else
            {
                tempId = String.Concat("0", "0", (int.Parse(tempId) + 1).ToString());
            }
            Dzial dzial = Dokument.Biblioteka.Dzialy.DzialList.Find(x => x.NazwaDzialu.ToString().Equals(DziałBox.Text));
            Dokument.Biblioteka.DanyDzialList.Find(x => x.Id == dzial.Id).Ksiazki.KsiazkaList.Add(new Ksiazka()
            {
                Id = tempId,
                Tytul = TytulBox.Text,
                Autorzy = new Autorzy() { AutorList = tempAutorList },
                IloscStron = int.Parse(IloscStronBox.Text),
                DataWydania = new DataWydania()
                {
                    Dzien = (tempCharTable != null) ? String.Concat(tempCharTable[0], tempCharTable[1]) : null,
                    Miesiac = (tempCharTable != null) ? String.Concat(tempCharTable[3], tempCharTable[4]): null,
                    Rok = (tempCharTable != null) ? String.Concat(tempCharTable[6], tempCharTable[7], tempCharTable[8], tempCharTable[9]): null
                }

            });

            if (Program.ValidateXmlSchema(Dokument))
            {
                Program.SaveData(Dokument);
                ListaKsiazek = new UI.ListaKsiazek(Dokument);
                this.ListaKsiazekListBox.DataContext = ListaKsiazek;
                TytulBox.Text = IloscStronBox.Text = DataWydaniaBox.Text = Autor1Box.Text = Autor2Box.Text = Autor3Box.Text = DziałBox.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Edycja danych niezgodna z XML Schema!", "Błąd!");
                Dokument = Program.LoadData();
            }
        }
    }
}
