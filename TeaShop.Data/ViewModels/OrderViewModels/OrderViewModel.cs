using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole Ulica jest wymagane")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole Nr domu jest wymagane")]
        [Display(Name = "Nr domu")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Pole Nr mieszkania jest wymagane")]
        [Display(Name = "Nr mieszkania")]
        public string FlatNumber { get; set; }

        [Required(ErrorMessage = "Pole Kod pocztowy jest wymagane")]
        [Display(Name = "Kod pocztowy")]
        [RegularExpression(@"\d{2}-\d{3}", ErrorMessage = "Wprowadź poprawny kod pocztowy w formacie 00-000")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Pole Miasto jest wymagane")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole Nr telefonu jest wymagane")]
        [RegularExpression(@"\d{9}", ErrorMessage = "Wprowadź poprawny numer telefonu składający sie z 9 cyfr")]
        [Display(Name = "Nr telefonu")]
        public int? Phone { get; set; }

        [Required(ErrorMessage = "Pole Forma płatności jest wymagane")]
        [Display(Name = "Forma płatności")]
        public Payment? Payment { get; set; }

        [Required(ErrorMessage = "Pole Sposób dostawy jest wymagane")]
        [Display(Name = "Sposób dostawy")]
        public Delivery? Delivery { get; set; }
    }
}
