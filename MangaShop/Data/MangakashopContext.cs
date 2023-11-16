using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MangaShop.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MangaShop.Data
{
    public class MangashopContext : IdentityDbContext<DefaultUser>
    {
        private const string MangashopContextConnectionString = "Server=tcp:mangakaserver.database.windows.net,1433;Initial Catalog=MangaShopDb;Persist Security Info=False;User ID=rayzor;Password=MangakashopAdmin@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MangashopContextConnectionString);

        }
        public MangashopContext(DbContextOptions<MangashopContext> options)
        : base(options)
        {
        }

        public DbSet<Manga> Mangas { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

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