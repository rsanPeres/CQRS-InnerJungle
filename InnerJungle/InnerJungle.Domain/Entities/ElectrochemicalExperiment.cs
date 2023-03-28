namespace InnerJungle.Domain.Entities
{
    public abstract class ElectrochemicalExperiment : Entity
    {
        public string Name { get; private set; }

        public ElectrochemicalExperiment(string name)
        {
            Name = name;
        }
    }
}
