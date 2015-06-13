using System;

namespace ddd.Core.Services
{
    public interface ISelfHostProvider : IDisposable
    {
        void Connect();
    }
}