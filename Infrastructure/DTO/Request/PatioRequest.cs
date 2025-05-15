using System.ComponentModel.DataAnnotations;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.OpenApi.MicrosoftExtensions;

namespace challenger.Infrastructure.DTO.Request
{
    public class PatioRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome do pátio é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo name deve ter no máximo 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        public int Capacidade   { get; set; }
    }
}
