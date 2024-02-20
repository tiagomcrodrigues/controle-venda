
using System.ComponentModel.DataAnnotations;

namespace ControleVenda.Api.Models.Responses
{
    public class ProdutoResponse
    { 
        public int Id { get;  set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        public string? Nome { get; set; }

        [Range(1, 100, ErrorMessage = "O campo valor Unitario deve conter entre 1 e 9.999.999.999.999.999,99")]
        public double ValorUnitario { get; set; }

        [Range(1, 100, ErrorMessage = "O campo valor Unitario deve conter entre 1 e 100")]
        public int Quantidade { get; set; }

        public CategoriaResponse Categoria { get; set; }

    }
}
