using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
            => await Table.FirstOrDefaultAsync(expression);

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> expression)
            => Table.Where(expression);

        public Task<T> GetByIdAsync(string id)
            => Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}