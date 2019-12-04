using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Dostawca
    {
        public Dostawca()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdDostawca { get; set; }
        public int Login { get; set; }
        public int Password { get; set; }
        public string Imie { get; set; }
        public string NumerTelefonu { get; set; }

        public virtual AktualnaLokalizacja AktualnaLokalizacja { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
