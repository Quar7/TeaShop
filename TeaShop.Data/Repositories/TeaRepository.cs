using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;

namespace TeaShop.Data.Repositories
{
    public class TeaRepository : ITeaRepository
    {
        private TeaShopDbContext _context;

        public TeaRepository(TeaShopDbContext context)
        {
            _context = context;
        }


        public void AddTea(Tea tea)
        {
            tea.IsActive = true;
            _context.Teas.Add(tea);
        }

        public void DecreaseQuantity(int id, int amount)
        {
            var tea = GetTeaById(id);
            tea.Quantity -= amount;
        }

        public IEnumerable<Tea> GetAllTeas()
        {
            return _context.Teas.Where(t => t.IsActive);
        }

        public Tea GetTeaById(int id)
        {
            return _context.Teas.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tea> GetTeasByCategory(TeaCategory category)
        {
            return _context.Teas.Where(t => t.Category == category).Where(t => t.IsActive);
        }

        public void DeactivateTea(Tea tea)
        {
            tea.IsActive = false;
            tea.Quantity = 0;
            UpdateTea(tea);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateTea(Tea tea)
        {
            _context.Teas.Update(tea);
        }
    }
}
