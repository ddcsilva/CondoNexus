using CondoNexus.Business.Models;
using CondoNexus.Domain.Utils;
using FluentValidation;

namespace CondoNexus.Business.Validations;

public class CondominioValidation : AbstractValidator<Condominio>
{
    public CondominioValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.CNPJ)
            .Must(DocumentoValidacao.ValidarCnpj).WithMessage("O CNPJ fornecido é inválido.");

        RuleFor(c => c.NumeroUnidades)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        RuleFor(c => c.NumeroBlocos)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        RuleFor(c => c.NumeroAndares)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
    }
}
