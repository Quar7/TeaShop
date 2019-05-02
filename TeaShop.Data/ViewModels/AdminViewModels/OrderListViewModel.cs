using System;
using System.Collections.Generic;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.ViewModels.AdminViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderTea> OrderTeas { get; set; }
    }
}
