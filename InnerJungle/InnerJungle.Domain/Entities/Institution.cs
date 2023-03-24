namespace InnerJungle.Domain.Entities
{
    public class Institution : Entity
    {
        public string Name { get; private set; }
        public IEnumerable<Research> Researches { get; private set; }
        public Institution(string name)
        {
            Name = name;
        }
    }
}
