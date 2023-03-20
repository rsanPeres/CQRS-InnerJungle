using InnerJungle.Domain.Enums;

namespace InnerJungle.Domain.Entities
{
    public class ExperimentBase : Entity
    {
        public string Title { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public ExperimentStatus Status { get; private set; }
        public IEnumerable<Eletrode> Eletrodes { get; private set; }
        public MicroorganismBase Microorganism { get; private set; }
        public IEnumerable<Nanomaterial> Nanomaterials { get; private set; }


        public ExperimentBase(string title)
        {
            Title = title;
            DateStart = DateTime.Now;
        }

        public bool SetDateEnd(DateTime dateEnd)
        {
            if (dateEnd >= DateTime.MinValue)
            {
                DateEnd = dateEnd;
                return true;
            }
            return false;
        }
    }
}
