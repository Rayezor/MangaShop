﻿using Microsoft.EntityFrameworkCore;
using MangaShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MangaShop.Data
{
    public class MangashopContext : IdentityDbContext<DefaultUser>
    {
        private const string MangashopContextConnectionString = "Server=tcp:mangakaserver.database.windows.net,1433;Initial Catalog=MangaShopDb;Persist Security Info=False;User ID=rayzor;Password=MangakashopAdmin@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public MangashopContext(DbContextOptions<MangashopContext> options)
        : base(options)
        {
        }

        //In memory database for Unit testing
        public static MangashopContext CreateForUnitTest()
        {
            var options = new DbContextOptionsBuilder<MangashopContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new MangashopContext(options);
        }

        //Db sets
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //Cascade delete used to delete Manga in a CartItem
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Manga)
                .WithMany()
                .HasForeignKey(c => c.MangaId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}