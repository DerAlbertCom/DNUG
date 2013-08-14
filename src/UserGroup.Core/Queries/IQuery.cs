using System.Linq;

namespace UserGroup.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<out T> : IQueryable<T> where T : class
    {
    }
}