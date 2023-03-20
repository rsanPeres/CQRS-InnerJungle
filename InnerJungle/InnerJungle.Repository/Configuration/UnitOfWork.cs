using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra.Contexts;
using InnerJungle.Repository.Repositories;
using Microsoft.Extensions.Logging;

namespace InnerJungle.Repository.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private readonly ILogger _logger;

        public IResearchRepository Research { get; private set; }

        public UnitOfWork(DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Research = new ResearchRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
