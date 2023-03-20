namespace InnerJungle.Domain.Entities
{
    public class Eletrode : EletrodeBase
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }

        public Eletrode(string type)
        {
            Type = type;
        }
    }
}
