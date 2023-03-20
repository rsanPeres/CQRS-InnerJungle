namespace InnerJungle.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IResearchRepository Research { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
