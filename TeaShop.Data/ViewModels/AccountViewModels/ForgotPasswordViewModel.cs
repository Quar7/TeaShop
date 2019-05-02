using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaShop.Data.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Musisz podać adres email")]
        [EmailAddress(ErrorMessage = "Wpisz poprawny adres email")]
        public string Email { get; set; }
    }
}
