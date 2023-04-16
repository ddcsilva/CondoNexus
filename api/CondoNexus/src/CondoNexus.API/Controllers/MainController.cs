using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CondoNexus.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificador _notificador;

    // Construtor que recebe INotificador como injeção de dependência
    protected MainController(INotificador notificador)
    {
        _notificador = notificador;
    }

    // Verifica se a operação foi válida (se não houver notificações de erro)
    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacao();
    }

    // Cria uma resposta personalizada com base no resultado e nas notificações de erro
    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
        });
    }

    // Cria uma resposta personalizada com base no ModelState
    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            NotificarErroModelInvalida(modelState);
        }

        return CustomResponse();
    }

    // Notifica erros no ModelState
    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);

        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(errorMsg);
        }
    }

    // Envia uma notificação de erro
    protected void NotificarErro(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}
