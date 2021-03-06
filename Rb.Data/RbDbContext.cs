﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rb.Data.Entities;

namespace Rb.Data
{
    public class RbDbContext : DbContext
    {
        public RbDbContext()
            : base("RbDatabase")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<GoogleSearchResult> GoogleSearchResults { get; set; }

        public DbSet<HathitrustResult> HathitrustResults { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<WorldcatResult> WorldcatResults { get; set; }

        public DbSet<YandexSearchResult> YandexSearchResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}