using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;

namespace SearchLogBrowser.Database
{
    class SLBDbContext : DbContext
    {
        public SLBDbContext() : base("DefaultContext") { }

        public DbSet<LSearchWord> LSearchWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("スキーマ名");
        }
    }
}
