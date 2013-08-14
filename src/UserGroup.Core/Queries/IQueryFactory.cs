namespace UserGroup.Queries
{
    public interface IQueryFactory
    {
        T Create<T>() where T : IQuery;
    }
}