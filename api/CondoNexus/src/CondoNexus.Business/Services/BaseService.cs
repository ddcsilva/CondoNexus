using CondoNexus.Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace CondoNexus.Business.Services;

public abstract class BaseService
{
    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }

    protected void Notificar(string mensagem)
    {

    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
    {
        var validationResult = validacao.Validate(entidade);

        if (validationResult.IsValid) return true;

        Notificar(validationResult);

        return false;
    }
}
