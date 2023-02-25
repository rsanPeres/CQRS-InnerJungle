using InnerJungle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Entities
{
    public class ExperimentBase : Entity
    {
        public string Title { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public ExperimentStatus Status { get; private set; }


        public ExperimentBase(string title)
        {
            Title = title;
            DateStart= DateTime.Now;
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
