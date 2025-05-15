using challenger.Domain.Entities;
using challenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace challenger.Infrastructure.Persistence.Repositories
{
    public class PatioRepository : Repository<Patio>, IPatioRepository
    {
        private readonly CGContext _context;
        private readonly DbSet<Patio> _dbSet;   

        public PatioRepository(CGContext context) : base(context) {

            _context = context;
            _dbSet = context.Set<Patio>();
        }

        public async Task<IEnumerable<Patio>> GetByCidadeAsync(string cidade)
        {
            return await _context.Patios
           .Where(p => p.Cidade == cidade)
           .ToListAsync();
        }
    }
}
