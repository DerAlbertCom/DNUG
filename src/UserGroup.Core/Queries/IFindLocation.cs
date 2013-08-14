using UserGroup.Entities;

namespace UserGroup.Queries
{
    public interface IFindLocation : IQuery
    {
        Location Execute(int locationId);
    }
}