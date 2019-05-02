using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;

namespace TeaShop.Data.Repositories
{
    public interface ITeaRepository
    {
        IEnumerable<Tea> GetAllTeas();
        IEnumerable<Tea> GetTeasByCategory(TeaCategory category);
        Tea GetTeaById(int id);
        void UpdateTea(Tea tea);
        void AddTea(Tea tea);
        void DeactivateTea(Tea tea);
        void DecreaseQuantity(int id, int amount);
        Task<bool> SaveAsync();
    }
}
