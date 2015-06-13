namespace ddd.Core.Entities
{
    public interface IParentable
    {
        long ParentId { get; }
        ParentEntityType ParentEntityType { get; }
    }
    public enum ParentEntityType
    {
        Widget = 0,
        Customer = 1
    }
}