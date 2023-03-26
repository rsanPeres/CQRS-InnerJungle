using InnerJungle.Domain.Enums;

namespace InnerJungle.Domain.Entities
{
    public class Seaweed : MicroorganismBase
    {
        public Seaweed(string name, string family, string genus, string species, DegreePhatogenicity phatogenicity, DegreeVirulence virulence) : base(name, family, genus, species, phatogenicity, virulence)
        {
        }
    }
}
