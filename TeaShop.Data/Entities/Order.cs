using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeaShop.Data.Entities
{
    public enum Payment
    {
        [Display(Name = "Płatność przelewem")]
        Przelew,
        [Display(Name = "Płatność kartą")]
        Karta,
        [Display(Name = "Płatność przy odbiorze")]
        Odbior
    }

    public enum Delivery
    {
        [Display(Name = "Kurier DHL")]
        Kurier,
        [Display(Name = "Poczta Polska")]
        Poczta,
        [Display(Name = "Paczkomat InPost")]
        Paczkomat
    }


    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public Payment Payment { get; set; }
        public Delivery Delivery { get; set; }
        public bool Completed { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderTea> OrderTeas { get; set; }
    }
}
