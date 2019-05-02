using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaShop.Data.Entities
{
    public enum TeaCategory
    {
        [Display(Name = "Herbata czarna")]
        Czarna,
        [Display(Name = "Herbata zielona")]
        Zielona,
        [Display(Name = "Herbata biała")]
        Biała
    }

    public class Tea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeaCategory Category { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public ICollection<OrderTea> OrderTeas { get; set; }
    }
}
