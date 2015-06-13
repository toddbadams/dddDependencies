using System;

namespace ddd.Core.Providers
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
        long UtcNowUnix { get; }
    }
}