using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using UserGroup.Entities;

namespace UserGroup.Data
{
    public class UserGroupDbContext : DbContext
    {

        public UserGroupDbContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
            
        }

        protected UserGroupDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                // Diese Exception sollte im Betrieb nicht auftreten, jedoch kann es beim Entwickeln dazu kommen dass
                // die Werte mit der die Datenbank beim erstellen initialisiert wird Fehler enth�lt. Dazu einfach beim
                // throw einen Breakpoint setzten und reindebuggen
                var sb = new StringBuilder();
                foreach (var entityValidationError in e.EntityValidationErrors)
                {
                    sb.AppendLine(entityValidationError.Entry.Entity.GetType().Name);
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        sb.AppendFormat("  {0}: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                var errors = sb.ToString();
                throw new DataException(errors, e);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Speaker>()
                .Ignore(s => s.FullName);

            modelBuilder.Entity<Meeting>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Location>();
            modelBuilder.Entity<Talk>().HasMany(t => t.Speakers).WithMany();
            modelBuilder.Entity<Page>();
        }

        public DbSet<Talk> Talks { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Person> People { get; set; }

    }
}