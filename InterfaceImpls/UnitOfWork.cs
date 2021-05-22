using Core.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ETourDbContext _dbContext;

        public UnitOfWork(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
