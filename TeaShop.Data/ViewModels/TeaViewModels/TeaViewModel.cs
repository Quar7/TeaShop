using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;

namespace TeaShop.Data.ViewModels.TeaViewModels
{
    public class TeaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeaCategory Category { get; set; }
        public string CountryOfOrigin { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
