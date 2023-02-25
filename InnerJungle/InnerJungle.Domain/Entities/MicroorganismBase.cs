using InnerJungle.Domain.Enums;

namespace InnerJungle.Domain.Entities
{
    public abstract class MicroorganismBase : Entity
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Genus { get; private set; }
        public string Species { get; private set; }
        public DegreePhatogenicity Phatogenicity { get; private set; }
        public DegreeVirulence Virulence { get; private set; }
        public Strain Strain { get; private set; }

        public MicroorganismBase(string name, string family, string genus, string species, DegreePhatogenicity phatogenicity, DegreeVirulence virulence, Strain strain)
        {
            Name = name;
            Family = family;
            Genus = genus;
            Species = species;
            Phatogenicity = phatogenicity;
            Virulence = virulence;
            Strain = strain;
        }
    }
}