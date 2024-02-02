namespace CrudProApi.Core
{
    public interface IUnitOfWork
    {
        IPersonelRepository Personel { get; }
        Task CompleteAsync();
    }
}
