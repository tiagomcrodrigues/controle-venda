using System.ComponentModel.DataAnnotations;

namespace ControleVenda.Api.Models.Requests
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 50 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Tipo Pessoa é obrigatório")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "O campo Tipo Pessoa deve (F) para pessoa fisica ou (J) para judridica")]
        public string? TipoPessoa { get; set; }

        [Required(ErrorMessage = "Campo documento é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo documento deve conter entre 11 e 14 caracteres")]
        public string? Documento { get; set; }

        [Required(ErrorMessage = "Campo Tipo logradouro é obrigatório")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo Tipo logradouro deve conter entre 2 e 30 caracteres")]
        public string? TipoLogradouro { get; set; }

        [Required(ErrorMessage = "Campo logradouro é obrigatório")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O campo logradouro deve conter entre 2 e 80 caracteres")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "Campo numero é obrigatório")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo numero deve conter entre 2 e 20 caracteres")]
        public string? Numero { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo comlemento deve conter entre 2 e 50 caracteres")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Campo bairro é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo bsirro deve conter entre 2 e 50 caracteres")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "Campo cidade é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo cidade deve conter entre 2 e 100 caracteres")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "Campo Uf é obrigatório")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo Uf deve conter entre 2 e 20 caracteres")]
        public string? Uf { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "O campo telefone deve conter 15 caracteres")]
        public string? Telefone { get; set; }

        [StringLength(254, MinimumLength = 2, ErrorMessage = "O campo Email deve conter entre 2 e 254 caracteres")]
        public string? Email { get; set; }

    }
}
