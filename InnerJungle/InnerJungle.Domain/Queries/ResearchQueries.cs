using InnerJungle.Domain.Entities;
using System.Linq.Expressions;

namespace InnerJungle.Domain.Queries
{
    public static class ResearchQueries
    {
        public static Expression<Func<Research, bool>> GetAll(User user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<Research, bool>> GetAllDone(User user)
        {
            return x => x.User == user && x.Done;
        }

        public static Expression<Func<Research, bool>> GetAllUndone(User user)
        {
            return x => x.User == user && x.Done == false;
        }

        public static Expression<Func<Research, bool>> GetByPeriod(User user, DateTime date, bool done)
        {
            return x => x.User == user &&
                        x.Done == done &&
                        x.Start.Date == date.Date;
        }
    }
}
