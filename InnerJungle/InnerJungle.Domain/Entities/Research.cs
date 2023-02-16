using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Entities
{
    public class Research : Entity
    {
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public User User { get; private set; }
        public Institution Institution { get; private set; }
        public string EletrodeType { get; private set; }
        public string EletrodeModification { get; private set; }
        public MicroorganismBase Microorganism { get; private set; }
        public IEnumerable<Experiment> Experiments { get; private set; }
        public IEnumerable<CalibrationCurve> CalibrationCurves { get; private set; }

        public Research(string title, bool done, string user) : base(id: Guid.NewGuid())
        {
            Title = title;
            Done = done;
            User = user;
            Start = DateTime.UtcNow;
        }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUnDone()
        {
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}
