namespace CondoNexus.Business.Models;

/// <summary>
/// Representa um morador de uma unidade residencial.
/// </summary>
public class Morador : BaseEntity
{
    public Morador()
    {
        Nome = string.Empty;
        CPF = string.Empty;
        Telefone = string.Empty;
        Email = string.Empty;
    }

    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public int UnidadeId { get; set; }

    // Relacionamento N:1 com Unidade
    public Unidade? Unidade { get; set; }
}
