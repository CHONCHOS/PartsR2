using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartsR2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PartsR2.DAL
{
    public class PRContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                  
        }
    }
}