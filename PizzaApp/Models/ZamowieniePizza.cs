using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class ZamowieniePizza
    {
        public Guid ZamowienieNumerZamowienia { get; set; }
        public Guid PizzaIdPizza { get; set; }
        public int Ilosc { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Zamowienie ZamowienieNumerZamowieniaNavigation { get; set; }
    }
}
