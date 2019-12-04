using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class AktualnaLokalizacja
    {
        public int DostawcaIdDostawca { get; set; }
        public DateTime CzasPobrania { get; set; }

        public virtual Dostawca DostawcaIdDostawcaNavigation { get; set; }
    }
}
