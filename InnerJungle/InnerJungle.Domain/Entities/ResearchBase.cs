namespace InnerJungle.Domain.Entities
{
    public abstract class ResearchBase : Entity
    {
        public string Title { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }

        public ResearchBase(string title)
        {
            Start = DateTime.UtcNow;
            Title = title;
        }

        public void MarkAsDone()
        {
            End = DateTime.UtcNow;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}
