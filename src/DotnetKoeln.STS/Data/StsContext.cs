using System.Data.Entity;
using DotnetKoeln.STS.Entities;

namespace DotnetKoeln.STS.Data
{
    public class StsContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WebUser>().ToTable("WebUser");
            modelBuilder.Entity<WebUser>().Ignore(w=>w.Modified);
        }

        public DbSet<WebUser> WebUsers { get; set; }
    }
}