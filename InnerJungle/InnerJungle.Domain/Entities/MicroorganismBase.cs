using InnerJungle.Domain.Enums;

namespace InnerJungle.Domain.Entities
{
    public class MicroorganismBase : Entity
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Genus { get; private set; }
        public string Species { get; private set; }
        public DegreePhatogenicity Phatogenicity { get; private set; }
        public DegreeVirulence Virulence { get; private set; }
        public Strain Strain { get; private set; }

    }
}