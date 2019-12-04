using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Typ
    {
        public Typ()
        {
            Skladnik = new HashSet<Skladnik>();
        }

        public int IdTyp { get; set; }
        public int Nazwa { get; set; }

        public virtual ICollection<Skladnik> Skladnik { get; set; }
    }
}
