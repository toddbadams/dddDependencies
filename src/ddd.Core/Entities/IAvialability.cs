using System.Security.Cryptography.X509Certificates;

namespace ddd.Core.Entities
{
    public interface IAvialability
    {
        int[] Start { get; set; }
        int[] End { get; set; }
    }
}