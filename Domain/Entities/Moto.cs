using challenger.Domain.Enum;

namespace challenger.Domain.Entities
{
    public class Moto : Audit
    {
        public Guid Id { get; private set; }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }

        public StatusMoto Status { get; private set; }

        public Guid PatioId { get; private set; }
        public Patio Patio { get; private set; }
    }
}
