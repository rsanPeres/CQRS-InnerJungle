namespace InnerJungle.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IResearchRepository Research { get; }
        IUserRepository User { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
