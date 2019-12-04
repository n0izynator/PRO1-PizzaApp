using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Promocja
    {
        public int IdPromocja { get; set; }
        public int Nazwa { get; set; }
        public int CenaPromocyjna { get; set; }
        public DateTime AktualnaOd { get; set; }
        public Guid PizzaIdPizza { get; set; }
        public DateTime AktualnaDo { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
