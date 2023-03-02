﻿using InnerJungle.Domain.Enums;

namespace InnerJungle.Domain.Entities
{
    public class Virus : MicroorganismBase
    {
        public Virus(string name, string family, string genus, string species, DegreePhatogenicity phatogenicity, DegreeVirulence virulence, Strain strain) : base(name, family, genus, species, phatogenicity, virulence, strain)
        {
        }
    }
}
