using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            Promocja = new HashSet<Promocja>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public Guid IdPizza { get; set; }
        public string Slug { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public byte[] Zdjecie { get; set; }

        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual ICollection<Promocja> Promocja { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
