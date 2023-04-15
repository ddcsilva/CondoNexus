using CondoNexus.Business.Interfaces;

namespace CondoNexus.Business.Notifications;

public class Notificador : INotificador
{
    // Lista interna de notificações
    private List<Notificacao> _notificacoes;

    public Notificador()
    {
        _notificacoes = new List<Notificacao>();
    }

    // Adiciona uma nova notificação à lista
    public void Handle(Notificacao notificacao)
    {
        _notificacoes.Add(notificacao);
    }

    // Retorna todas as notificações armazenadas na lista
    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }

    // Verifica se existem notificações na lista
    public bool TemNotificacao()
    {
        return _notificacoes.Any();
    }
}
