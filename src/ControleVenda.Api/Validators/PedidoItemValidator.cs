using ControleVenda.Api.Models.Requests;
using FluentValidation;

namespace ControleVenda.Api.Validators
{
    public class PedidoItemValidator : AbstractValidator<PedidoItemRequest>
    {

        public PedidoItemValidator()
        {

            RuleFor(i => i.ProdutoId)
                .NotNull().WithMessage("O id do produto deve ser informado")
                .GreaterThan(0).WithMessage("O id do produto é inválido")
            ;

            RuleFor(i => i.Quantidade)
                .NotNull().WithMessage("A quantidade deve ser informada")
                .GreaterThan(0).WithMessage("A quantidade deve ser maior do que zero (0)")
            ;

        }

    }
}
