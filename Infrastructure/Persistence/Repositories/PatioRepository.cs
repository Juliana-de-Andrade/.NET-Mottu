using challenger.Domain.Entities;
using challenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace challenger.Infrastructure.Persistence.Repositories
{
    public class PatioRepository : Repository<Patio>, IPatioRepository
    {
        private readonly CGContext _context;
        

        public PatioRepository(CGContext context) : base(context) {

            _context = context;
            
        }

        public async Task<IEnumerable<Patio>> GetByCidadeAsync(string cidade)
        {
            return await _context.Patios
           .Where(p => p.Cidade == cidade)
           .ToListAsync();
        }
    }
}
