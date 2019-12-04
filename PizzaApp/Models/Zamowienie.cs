using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public Guid NumerZamowienia { get; set; }
        public string Slug { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }
        public int StanIdStan { get; set; }
        public int DostawcaIdDostawca { get; set; }
        public int CenaZamowienia { get; set; }
        public string Ulica { get; set; }
        public int NumerDomu { get; set; }
        public int? NumerMieszkania { get; set; }
        public DateTime SzacowanyCzasDostawy { get; set; }

        public virtual Dostawca DostawcaIdDostawcaNavigation { get; set; }
        public virtual Stan StanIdStanNavigation { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
