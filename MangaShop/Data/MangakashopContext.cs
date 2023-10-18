using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MangaShop.Models;
using System.Diagnostics;

namespace MangaShop.Data
{
    public class MangashopContext : DbContext
    {
        private const string MangashopContextConnectionString = "Server=tcp:mangakaserver.database.windows.net,1433;Initial Catalog=MangaShopDb;Persist Security Info=False;User ID=rayzor;Password=MangakashopAdmin@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MangashopContextConnectionString);

        }

        public DbSet<Manga> Mangas { get; set; }
    }
}
