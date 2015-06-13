using System;

namespace ddd.Core.Services
{
    public interface IMicroService
    {
        event Action OnServiceStarted;
        event Action OnServiceStopped;
        void Run(string[] args);
    }
}