namespace ddd.Core.Providers
{
    public interface IHashProvider
    {
        string GetHash(string input);
    }
}