using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra.Contexts;
using InnerJungle.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InnerJungle.Repository.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private readonly ILogger _logger;

        public IResearchRepository Research { get; private set; }
        public IUserRepository User { get; private set; }

        public UnitOfWork(DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Research = new ResearchRepository(_context, _logger);
            User = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.StackTrace, ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
