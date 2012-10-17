namespace UserGroup.Entities
{
    public interface IHasLocation
    {
        Location Location { get; }         
    }

    public interface IHasMeeting
    {
        Meeting Meeting { get; }
    }
}