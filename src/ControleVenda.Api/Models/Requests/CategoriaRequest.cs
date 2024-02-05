using System.ComponentModel.DataAnnotations;

namespace ControleVenda.Api.Models.Requests
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(100,MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        public string Nome { get; set; }

    }
}
