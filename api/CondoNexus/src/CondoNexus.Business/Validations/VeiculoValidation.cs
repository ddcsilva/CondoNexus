using CondoNexus.Business.Models;
using FluentValidation;

namespace CondoNexus.Business.Validations;

public class VeiculoValidation : AbstractValidator<Veiculo>
{
    public VeiculoValidation()
    {
        RuleFor(v => v.Placa)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(7)
            .WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

        RuleFor(v => v.Marca)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(1, 50)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(v => v.Modelo)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(1, 50)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(v => v.Cor)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(1, 30)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(v => v.Ano)
            .GreaterThanOrEqualTo(1900).WithMessage("O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}")
            .LessThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("O campo {PropertyName} precisa ser menor ou igual ao ano atual");
    }
}
