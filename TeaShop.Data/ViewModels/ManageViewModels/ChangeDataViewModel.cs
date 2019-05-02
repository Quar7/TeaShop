using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeaShop.Data.ViewModels.ManageViewModels
{
    public class ChangeDataViewModel
    {
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Regulamin")]
        public bool AcceptedRules { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Nr domu")]
        public string HouseNumber { get; set; }

        [Display(Name = "Nr mieszkania")]
        public string FlatNumber { get; set; }

        [Display(Name = "Kod pocztowy")]
        [RegularExpression(@"\d{2}-\d{3}", ErrorMessage = "Wprowadź poprawny kod pocztowy w formacie 00-000")]
        public string ZipCode { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [RegularExpression(@"\d{9}", ErrorMessage = "Wprowadź poprawny numer telefonu składający sie z 9 cyfr")]
        [Display(Name = "Nr telefonu")]
        public int? Phone { get; set; }
    }
}
