namespace Lottery.Data.Model
{
    // A base entity interface that defines all the entities in the application with the properties needed for all of them
    // This class usually have shared properties such as DateCreated, IsDeleted, DateModified etc.
    public interface IEntity
    {
        int Id { get; set; }
    }
}
