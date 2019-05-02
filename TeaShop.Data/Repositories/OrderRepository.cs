using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShop.Data.Entities;

namespace TeaShop.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private TeaShopDbContext _context;

        public OrderRepository(TeaShopDbContext context)
        {
            _context = context;
        }


        public void AddOrder(Order order)
        {
            _context.AttachRange(order.OrderTeas.Select(c => c.Tea));
            _context.Orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders
                .OrderBy(o => o.Completed)
                .ThenByDescending(o => o.Date)
                .Include(o => o.Customer);
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderTeas)
                .ThenInclude(ot => ot.Tea)
                .SingleOrDefault(o => o.Id == id);
        }

        public Order GetOrderDetailsByCustomer(string id, int orderId)
        {
            return _context.Orders
                .Include(o => o.OrderTeas)
                .ThenInclude(ot => ot.Tea)
                .SingleOrDefault(o => o.CustomerId == id && o.Id == orderId);
        }

        public IEnumerable<Order> GetOrdersByCustomer(string id)
        {
            return _context.Orders
                .OrderBy(o => o.Completed)
                .ThenByDescending(o => o.Date)
                .Where(o => o.CustomerId == id);
        }

        public void UpdateState(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
