﻿using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;


namespace SupermarketWEB.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public DbSet<PayMode> PayModes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}