namespace InnerJungle.Domain.Entities
{
    public class Oligonucleotide : CharacteristicsCommercialMicroorganism
    {
        public Oligonucleotide(string name, string brand, string storageTemperature, DateTime arrival, DateTime dueDate, decimal dilution) : base(name, brand, storageTemperature, arrival, dueDate, dilution)
        {
        }
    }
}
