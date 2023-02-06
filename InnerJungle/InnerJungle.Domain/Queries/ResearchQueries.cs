using InnerJungle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Queries
{
    public static class ResearchQueries
    {
        public static Expression<Func<Research, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<Research, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done;
        }

        public static Expression<Func<Research, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }

        public static Expression<Func<Research, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x => x.User == user && 
                        x.Done == done &&
                        x.Start.Date == date.Date;
        }
    }
}
