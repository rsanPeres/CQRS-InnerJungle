using InnerJungle.Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace InnerJungle.Domain.Entities
{
    public class Bacterium : MicroorganismBase
    {
        public Bacterium(string name, string family, string genus, string species, DegreePhatogenicity phatogenicity, DegreeVirulence virulence, Strain strain) : base(name, family, genus, species, phatogenicity, virulence, strain)
        {
        }

        public bool GramPositive { get; private set; }
        
    }
}
