using System.Data.Entity;

namespace UserGroup.Data
{
    public interface IDbContextFactory
    {
        DbContext Create();
    }
}