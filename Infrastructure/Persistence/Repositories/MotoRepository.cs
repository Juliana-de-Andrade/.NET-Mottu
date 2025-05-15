using challenger.Domain.Entities;
using challenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace challenger.Infrastructure.Persistence.Repositories
{
    public class MotoRepository : Repository<Moto>, IMotoRepository
    {
        private readonly CGContext _context;
        

        public MotoRepository(CGContext context) : base(context)
        { 
            _context = context;
        }

        public async Task<Moto?> GetByPlacaAsync(string placa)
        {
            return await _context.Motos
                   .FirstOrDefaultAsync(m => m.Placa == placa);
        }
    }
}
