using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entities;

namespace ShoppingCart.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext (DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingCart.Entities.Product> Product { get; set; }

        public DbSet<ShoppingCart.Entities.Cart> Cart { get; set; }
        public DbSet<ShoppingCart.Entities.CartDetail> CartDetail { get; set; }
    }
}
