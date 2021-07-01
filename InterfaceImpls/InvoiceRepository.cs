using Core.Entities;
using Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ETourDbContext _dbContext;

        public InvoiceRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Invoice> Queryable => _dbContext.Invoices;

        public async Task<Invoice> AddAsync(Invoice entity)
        {
            await _dbContext.Invoices.AddAsync(entity);
            return entity;
        }

        public Task<Invoice> DeleteAsync(Invoice entity)
        {
            _dbContext.Invoices.Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<Invoice> FindAsync(int key)
        {
            return await _dbContext.Invoices.FindAsync(key);
        }

        public Task<Invoice> UpdateAsync(Invoice entity)
        {
            _dbContext.Invoices.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
