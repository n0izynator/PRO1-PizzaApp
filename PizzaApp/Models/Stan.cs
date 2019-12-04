using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Stan
    {
        public Stan()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdStan { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
