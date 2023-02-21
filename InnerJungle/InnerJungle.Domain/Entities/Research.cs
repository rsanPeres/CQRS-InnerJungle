using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Entities
{
    public class Research : ResearchBase
    {
        public User User { get; private set; }
        public Institution Institution { get; private set; }
        public Eletrode Eletrode { get; private set; }
        public Microorganism Microorganism { get; private set; }
        public IEnumerable<Experiment> Experiments { get; private set; }
        public IEnumerable<CalibrationCurve> CalibrationCurves { get; private set; }

        public Research(string title, User user) : base(title)
        {
            User = user;
        }
    }
}
