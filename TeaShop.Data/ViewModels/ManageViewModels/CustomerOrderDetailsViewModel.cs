using System;
using System.Collections.Generic;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.ViewModels.ManageViewModels
{
    public class CustomerOrderDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public Payment Payment { get; set; }
        public Delivery Delivery { get; set; }
        public bool Completed { get; set; }

        public ICollection<OrderTea> OrderTeas { get; set; }
    }
}
