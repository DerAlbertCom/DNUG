using System.Data.Entity;
using Devart.Data.SQLite;
using UserGroup.Data;

namespace UserGroup.Core.Specs
{
    public class UnitTestDbContext : UserGroupDbContext
    {
        public UnitTestDbContext() : base(CreateConnectionString())
        {
        }

        static string CreateConnectionString()
        {
            return new SQLiteConnectionStringBuilder
            {
                DataSource = ":memory:",
                ForeignKeyConstraints = SQLiteForeignKeyConstraints.On
            }.ConnectionString;
        }
    }

    public class UnitTestInitializer : DropCreateDatabaseAlways<UnitTestDbContext>
    {

    }
}