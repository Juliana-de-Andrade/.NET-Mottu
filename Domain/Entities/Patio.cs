namespace challenger.Domain.Entities
{
    public class Patio : Audit
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Cidade { get; private set; }
        public int Capacidade { get; private set; }


        public List<Moto> Motos { get; private set; } 

    }
}
