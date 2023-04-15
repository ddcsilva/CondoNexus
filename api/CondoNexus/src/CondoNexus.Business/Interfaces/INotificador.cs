using CondoNexus.Business.Notifications;

namespace CondoNexus.Business.Interfaces;

public interface INotificador
{
    // Verifica se existem notificações armazenadas
    bool TemNotificacao();

    // Obtém a lista de notificações armazenadas
    List<Notificacao> ObterNotificacoes();

    // Manipula e armazena uma nova notificação
    void Handle(Notificacao notificacao);
}
