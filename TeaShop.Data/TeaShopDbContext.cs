using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaShop.Data.Entities;

namespace TeaShop.Data
{
    public class TeaShopDbContext : IdentityDbContext<Customer>
    {
        public TeaShopDbContext(DbContextOptions<TeaShopDbContext> options) : base(options)
        {

        }

        public DbSet<Tea> Teas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderTea> OrderTeas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>().Ignore(c => c.AccessFailedCount)
                                      .Ignore(c => c.LockoutEnabled)
                                      .Ignore(c => c.LockoutEnd)
                                      .Ignore(c => c.PhoneNumber)
                                      .Ignore(c => c.PhoneNumberConfirmed)
                                      .Ignore(c => c.TwoFactorEnabled)
                                      .ToTable("Customers");

            builder.Entity<OrderTea>().HasKey(ot => new { ot.TeaId, ot.OrderId });
        }
    }
}
