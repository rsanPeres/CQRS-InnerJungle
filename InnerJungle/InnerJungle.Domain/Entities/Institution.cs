namespace InnerJungle.Domain.Entities
{
    public class Institution : Entity
    {
        public string Name { get; private set; }
        public ICollection<Research> Researches { get; private set; }
        public Institution(string name)
        {
            Name = name;
            Researches= new List<Research>();
        }
    }
}
