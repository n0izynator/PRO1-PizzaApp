using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AdresEmail { get; set; }
    }
}
