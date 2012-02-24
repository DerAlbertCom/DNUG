using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;

namespace UserGroup.Data
{
    public class UserGroupDbContext : DbContext
    {
        public UserGroupDbContext()
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
                // die Werte mit der die Datenbank beim erstellen initialisiert wird Fehler enthält. Dazu einfach bei
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
                throw;
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

    }
}