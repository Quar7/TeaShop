using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeaShop.Data.Entities;

namespace TeaShop.Data.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        IEnumerable<Order> GetOrdersByCustomer(string id);
        Order GetOrderDetailsByCustomer(string id, int orderId);
        void AddOrder(Order order);
        void UpdateState(Order order);
        Task<bool> SaveAsync();
    }
}
