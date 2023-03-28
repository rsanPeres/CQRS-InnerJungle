namespace InnerJungle.Domain.Entities
{
    public class Eletrode : EletrodeBase
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }
        public ICollection<Research> Researches { get; private set; }

        public Eletrode(string type, string name, decimal price, int amount)
        {
            Type = type;
            Name = name;
            Price = price;
            Amount = amount;
            Researches = new List<Research>();
        }
    }
}
