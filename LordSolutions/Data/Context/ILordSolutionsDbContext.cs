using LordSolutions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Context
{
    public interface ILordSolutionsDbContext
    {
        public DbSet<Cliente> clientes { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}