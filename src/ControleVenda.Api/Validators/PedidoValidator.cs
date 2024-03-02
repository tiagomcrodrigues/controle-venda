using ControleVenda.Api.Models.Requests;
using FluentValidation;

namespace ControleVenda.Api.Validators
{
    public class PedidoValidator : AbstractValidator<PedidoRequest>
    {

        public PedidoValidator()
        {

            RuleFor(p => p.ClenteId)
                .NotNull().WithMessage("O id do cliente deve ser informado")
                .GreaterThan(0).WithMessage("O id do cliente é inválido")
            ;

            RuleFor(p => p.Itens)
                .Must(x => x.Any()).WithMessage("Ao menos um item deve ser informado");

            RuleForEach(p => p.Itens)
                .SetValidator(new PedidoItemValidator());

        }

    }
}
