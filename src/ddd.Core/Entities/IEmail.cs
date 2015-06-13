namespace ddd.Core.Entities
{
    public interface IEmail
    {
        string Email { get; }
        bool IsEmailVerified { get; }
    }
}