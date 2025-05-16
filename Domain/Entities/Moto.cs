using System.Numerics;
using challenger.Domain.Enum;
using challenger.Infrastructure.DTO.Request;

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
        
        public Moto(MotoRequest motoRequest)
        {
            Id = Guid.NewGuid();
            Placa = motoRequest.Placa;
            Modelo = motoRequest.Modelo;
            PatioId = motoRequest.PatioId;
            Status = StatusMoto.INATIVA;
        }

        public Moto()
        {
            
        }

        public void Update(MotoRequest motoRequest)
        {
            Placa = motoRequest.Placa;
            Modelo = motoRequest.Modelo;
            PatioId = motoRequest.PatioId;

            Updated = "sistema"; // ou usuário autenticado
            DataUpadated = DateTime.UtcNow;
        }
        public void Inativa()
        {
            if (Status == StatusMoto.INATIVA)
                throw new InvalidOperationException("Moto está desativada");

            Status = StatusMoto.INATIVA;
        }

        public void Ativa()
        {
            if (Status == StatusMoto.DISPONIVEL)
                throw new InvalidOperationException("Moto está disponivel");

            Status = StatusMoto.DISPONIVEL;

        }

        public void Manutencao()
        {
            if (Status == StatusMoto.EM_MANUTENCAO)
                throw new InvalidOperationException("A moto está em manutencao");

            Status = StatusMoto.EM_MANUTENCAO;
        }

        public void Uso()
        {
            if (Status == StatusMoto.EM_USO)
                throw new InvalidOperationException("A moto está sendo utilizada");

            Status = StatusMoto.EM_USO;
        }
    }
}
