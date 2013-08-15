using UserGroup.Entities;

namespace UserGroup.Queries
{
    public interface IFindLocation
    {
        Location Execute(int locationId);
    }
}