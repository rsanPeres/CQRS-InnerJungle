using System.Security.Cryptography.X509Certificates;

namespace InnerJungle.Domain.Entities
{
    public class Bacterium : MicroorganismBase
    {
        public bool GramPositive { get; private set; }
        public Bacterium()
        {
        }
    }
}
