using challenger.Domain.Entities;

namespace challenger.Infrastructure.Persistence.Repositories
{
    public interface IPatioRepository : IRepository<Patio>
    {
        Task<IEnumerable<Patio>> GetByCidadeAsync(string cidade);
    }

}
