using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace CondoNexus.Business.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    // Notifica um ValidationResult com erros de validação
    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }

    // Notifica uma mensagem de erro simples
    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }

    // Executa a validação e retorna um booleano indicando se a validação foi bem-sucedida
    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }
}
