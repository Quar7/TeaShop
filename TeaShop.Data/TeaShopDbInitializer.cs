using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;

namespace TeaShop.Data
{
    public class TeaShopDbInitializer
    {
        private TeaShopDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<Customer> _userManager;

        public TeaShopDbInitializer(TeaShopDbContext context, RoleManager<IdentityRole> roleManager, UserManager<Customer> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //Initial Products
        private List<Tea> _teas = new List<Tea>
        {
            new Tea
            {
                Category = (TeaCategory)0,
                Name = "Noc",
                CountryOfOrigin = "Chiny",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 12,
                Quantity = 20,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)1,
                Name = "Liść",
                CountryOfOrigin = "Indie",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 22,
                Quantity = 44,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)2,
                Name = "Orzeł",
                CountryOfOrigin = "Sri Lanka",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 18,
                Quantity = 18,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)2,
                Name = "Śnieżka",
                CountryOfOrigin = "Chiny",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 28,
                Quantity = 28,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)2,
                Name = "Bałwan",
                CountryOfOrigin = "Chiny",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 69,
                Quantity = 0,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)1,
                Name = "Las",
                CountryOfOrigin = "Chiny",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 19,
                Quantity = 0,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)0,
                Name = "Kruk",
                CountryOfOrigin = "Indie",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 77,
                Quantity = 48,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)2,
                Name = "Księżyc",
                CountryOfOrigin = "Indie",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 40,
                Quantity = 20,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)1,
                Name = "Madagaskar",
                CountryOfOrigin = "Sri Lanka",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 59,
                Quantity = 80,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)0,
                Name = "Cień",
                CountryOfOrigin = "Indie",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 26,
                Quantity = 5,
                IsActive = true
            },

            new Tea
            {
                Category = (TeaCategory)0,
                Name = "Węgiel",
                CountryOfOrigin = "Indie",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Price = 19,
                Quantity = 10,
                IsActive = true
            }
        };

        //Admin User
        private Customer _admin = new Customer
        {
            FirstName = "Admin",
            Email = "admin@admin",
            EmailConfirmed = true,
            NormalizedEmail = "ADMIN@ADMIN",
            NormalizedUserName = "ADMIN@ADMIN",
            UserName = "admin@admin",
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        //Initialize database
        public async Task Initialize()
        {
            if (!_context.Teas.Any())
            {
                _context.Teas.AddRange(_teas);
                await _context.SaveChangesAsync();
            }

            if (!await _roleManager.RoleExistsAsync("Administrator") && !_context.Users.Any(u => u.UserName == _admin.UserName))
            {
                var adminRole = new IdentityRole
                {
                    Name = "Administrator"
                };
                await _roleManager.CreateAsync(adminRole);
                var result = await _userManager.CreateAsync(_admin, "Admin123");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(_admin, "Administrator");
                }
            }

            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                var adminRole = new IdentityRole
                {
                    Name = "Customer"
                };
                await _roleManager.CreateAsync(adminRole);
            }
        }
    }
}
