namespace InnerJungle.Domain.Entities
{
    public abstract class CharacteristicsCommercialMicroorganism : Entity
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public string StorageTemperature { get; private set; }
        public DateTime Arrival { get; private set; }
        public DateTime DueDate { get; private set; }
        public Decimal Dilution { get; private set; }

        public CharacteristicsCommercialMicroorganism(string name, string brand, string storageTemperature, DateTime arrival, DateTime dueDate, decimal dilution)
        {
            Name = name;
            Brand = brand;
            StorageTemperature = storageTemperature;
            Arrival = arrival;
            DueDate = dueDate;
            Dilution = dilution;
        }
    }
}
