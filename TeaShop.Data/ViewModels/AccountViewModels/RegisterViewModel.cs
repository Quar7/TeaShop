using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaShop.Data.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole Email jest wymagane")]
        [EmailAddress(ErrorMessage = "Wpisz poprawny adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [StringLength(20, ErrorMessage = "Hasło musi składać się z od {2} do {1} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Musisz zaakceptować regulamin")]
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
