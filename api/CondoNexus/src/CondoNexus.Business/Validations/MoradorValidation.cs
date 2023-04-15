using CondoNexus.Business.Models;
using CondoNexus.Domain.Utils;
using FluentValidation;

namespace CondoNexus.Business.Validations;

public class MoradorValidation : AbstractValidator<Morador>
{
    public MoradorValidation()
    {
        RuleFor(m => m.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(m => m.CPF)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(11).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres")
            .Must(DocumentoValidation.ValidarCpf).WithMessage("O CPF fornecido é inválido.");

        RuleFor(m => m.Telefone)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(10, 11).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(m => m.Email)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .EmailAddress().WithMessage("O campo {PropertyName} deve conter um endereço de e-mail válido");

        RuleFor(m => m.DataNascimento)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage("O campo {PropertyName} precisa ser menor ou igual à data atual menos 18 anos");
    }
}