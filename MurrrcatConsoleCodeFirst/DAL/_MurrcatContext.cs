using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class MurrcatContext : DbContext
    {
        public MurrcatContext() : base() { }

        public MurrcatContext(DbContextOptions options) : base(options) { }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new ConnectionStringManager().ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
