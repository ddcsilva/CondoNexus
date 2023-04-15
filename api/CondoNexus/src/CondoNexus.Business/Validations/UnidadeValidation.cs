using CondoNexus.Business.Models;
using FluentValidation;

namespace CondoNexus.Business.Validations;

public class UnidadeValidation : AbstractValidator<Unidade>
{
    public UnidadeValidation()
    {
        RuleFor(u => u.Numero)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(1, 10)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(u => u.Andar)
            .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}");

        RuleFor(u => u.Bloco)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(1, 10)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
    }
}
