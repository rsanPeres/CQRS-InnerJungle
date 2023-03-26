using Flunt.Notifications;
using Flunt.Validations;

namespace InnerJungle.Domain.Entities
{
    public class Research : ResearchBase
    {
        public User User { get; private set; }
        public Institution Institution { get; private set; }
        public Eletrode Eletrode { get; private set; }
        public IEnumerable<MicroorganismBase> Microorganism { get; private set; }
        public IEnumerable<ExperimentBase> Experiments { get; private set; }
        public IEnumerable<ElectrochemicalExperiment> ElectrochemicalExperiments { get; private set; }
        public CalibrationCurve CalibrationCurve { get; private set; } 
        public IEnumerable<Nanomaterial> Nanomaterials { get; private set; }

        public Research(string title) : base(title)
        {
            Microorganism = new List<MicroorganismBase>();
            Experiments = new List<ExperimentBase>();
            ElectrochemicalExperiments = new List<ElectrochemicalExperiment>();
            Nanomaterials= new List<Nanomaterial>();
            CalibrationCurve= new CalibrationCurve();
        }
        public void validate(User user, MicroorganismBase microorganism)
        {
            AddNotifications(new Contract<Notification>()
              .IsNotNull(user, "User must be valid")
              .IsNotNull(microorganism, "microorganism must be valid"));
        }
    }
}
