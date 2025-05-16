using challenger.Infrastructure.DTO.Request;

namespace challenger.Domain.Entities
{
    public class Patio : Audit
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Cidade { get; private set; }
        public int Capacidade { get; private set; }


        public List<Moto> Motos { get; private set; }

        public Patio()
        {

        }

        public Patio(PatioRequest patioRequest)
        {
            Id = Guid.NewGuid();
            Name = patioRequest.Name;
            Cidade = patioRequest.Cidade;
            Capacidade = patioRequest.Capacidade;

            Created = "Sistema"; // Ou algum usuário real
            DataCreated = DateTime.UtcNow;
            Updated = "Sistema";
            DataUpadated = DateTime.UtcNow;
        }

        public void Update(PatioRequest request)
        {
            Name = request.Name;
            Cidade = request.Cidade;
            Capacidade = request.Capacidade;

            Updated = "sistema"; // ou obtenha do usuário autenticado
            DataUpadated = DateTime.UtcNow;
        }

    }
}
