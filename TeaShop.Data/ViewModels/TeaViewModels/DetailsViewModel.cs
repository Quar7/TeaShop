using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.ViewModels.TeaViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa produktu jest wymagane")]
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Rodzaj produktu jest wymagane")]
        [Display(Name = "Rodzaj produktu")]
        public TeaCategory Category { get; set; }

        [Required(ErrorMessage = "Pole Kraj pochodzenia jest wymagane")]
        [Display(Name = "Kraj pochodzenia")]
        public string CountryOfOrigin { get; set; }

        [Display(Name = "Opis produktu")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole Cena produktu jest wymagane")]
        [Range(0.01, 10000.00, ErrorMessage = "Cena musi być większy od zera")]
        [RegularExpression(@"^\d+([,]\d{1,2})?$", ErrorMessage = "Wprowadź poprawną cenę")]
        [Display(Name = "Cena produktu [zł]")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Pole Dostepna ilość jest wymagane")]
        [Range(0, 10000, ErrorMessage = "Ilość nie może być ujemna")]
        [Display(Name = "Ilość [szt]")]
        public int Quantity { get; set; }
    }
}
