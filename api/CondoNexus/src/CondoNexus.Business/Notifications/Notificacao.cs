namespace CondoNexus.Business.Notifications;

public class Notificacao
{
    public Notificacao(string mensagem)
    {
        Mensagem = mensagem;
    }

    // Mensagem de erro da notificação
    public string Mensagem { get; }
}
