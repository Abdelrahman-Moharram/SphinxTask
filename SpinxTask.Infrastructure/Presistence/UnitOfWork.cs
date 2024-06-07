using SpinxTask.Core.Interfaces;
using SpinxTask.Core.Models;
using SpinxTask.Infrastructure.Data;

namespace SpinxTask.Infrastructure.Presistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Class> Classes { get; private set; }

        public IRepository<Client> Clients { get; private set; }

        public IRepository<ClientProduct> ClientProducts { get; private set; }

        public IRepository<Product> Products { get; private set; }

        public IRepository<State> States { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Classes         = new BaseRepository<Class>(_context);
            Clients         = new BaseRepository<Client>(_context);
            ClientProducts  = new BaseRepository<ClientProduct>(_context);
            Products        = new BaseRepository<Product>(_context);
            States          = new BaseRepository<State>(_context);
        }

        public int SaveAsync()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
