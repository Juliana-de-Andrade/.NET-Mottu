using challenger.Domain.Entities;

namespace challenger.Infrastructure.Persistence.Repositories
{
    public interface IMotoRepository : IRepository<Moto>
    {
        Task<Moto?> GetByPlacaAsync(string placa);
    }
}
