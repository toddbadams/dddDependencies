namespace ddd.Core.Services
{
    public interface IWindowsServiceManager
    {
        void Install();
        void UnInstall();
        void Start();
        void Stop();
    }
}