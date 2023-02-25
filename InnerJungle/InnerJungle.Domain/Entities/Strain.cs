namespace InnerJungle.Domain.Entities
{
    public class Strain : CharacteristicsCommercialMicroorganism
    {
        public string GrowthMedium { get; private set; }
        public Decimal GrowthTemperature { get; private set; }

        public Strain(string name, string brand, string storageTemperature, DateTime arrival, DateTime dueDate, decimal dilution, string growthMedium, decimal growthTemperature) : base(name, brand, storageTemperature, arrival, dueDate, dilution)
        {
            GrowthMedium = growthMedium;
            GrowthTemperature = growthTemperature;
        }
    }
}
