using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public int TypIdTyp { get; set; }
        public int Cena { get; set; }

        public virtual Typ TypIdTypNavigation { get; set; }
        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
    }
}
