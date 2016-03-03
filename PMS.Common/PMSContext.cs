using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public class PMSContext : DbContext
    {
        public PMSContext()
            : base("PMSContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<BookDemands> BookDemands { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
