using Flunt.Notifications;
using Flunt.Validations;

namespace InnerJungle.Domain.Entities
{
    public class Research : ResearchBase
    {
        public User? User { get; private set; }
        public Institution? Institution { get; private set; }
        public Eletrode? Eletrode { get; private set; }
        public ICollection<MicroorganismBase>? Microorganism { get; private set; }
        public ICollection<ExperimentBase>? Experiments { get; private set; }
        public CalibrationCurve? CalibrationCurve { get; private set; } 
        public ICollection<Nanomaterial>? Nanomaterials { get; private set; }

        private Research(string title) : base(title) { }

        public Research(string title, Eletrode eletrode, Institution institution, User user) : base(title)
        {
            Institution = institution;
            Eletrode= eletrode;
            Microorganism = new List<MicroorganismBase>();
            Experiments = new List<ExperimentBase>();
            Nanomaterials= new List<Nanomaterial>();
            User = user;
        }
        public void validate(User user, MicroorganismBase microorganism)
        {
            AddNotifications(new Contract<Notification>()
              .IsNotNull(user, "User must be valid")
              .IsNotNull(microorganism, "microorganism must be valid"));
        }

        public void SetUser(User user)
        {
            User = user;
        }
    }
}
