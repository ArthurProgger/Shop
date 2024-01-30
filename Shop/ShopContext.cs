﻿using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) => Database.EnsureCreated();
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PurchaseProduct> PurchasesProducts { get; set; }
        public DbSet<SaleProduct> SalesProducts { get; set; }
    }
}