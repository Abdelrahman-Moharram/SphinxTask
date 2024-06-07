using SpinxTask.Core.Models;

namespace SpinxTask.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Class> Classes { get; }

        IRepository<Client> Clients { get; }

        IRepository<ClientProduct> ClientProducts { get; }

        IRepository<Product> Products { get; }

        IRepository<State> States { get; }


        int SaveAsync();
    }
}
