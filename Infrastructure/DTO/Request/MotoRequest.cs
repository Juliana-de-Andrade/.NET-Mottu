using System.ComponentModel.DataAnnotations;

namespace challenger.Infrastructure.DTO.Request
{
    public class MotoRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória")]
        [MaxLength(8)]
        [MinLength(7)]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O id do patio é obrigatório")]
        public Guid PatioId { get; set; }
    }
}
