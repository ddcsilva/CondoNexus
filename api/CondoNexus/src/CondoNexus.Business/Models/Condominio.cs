namespace CondoNexus.Business.Models;

/// <summary>
/// Representa um condomínio.
/// </summary>
public class Condominio : BaseEntity
{
    public Condominio()
    {
        Nome = string.Empty;
        CNPJ = string.Empty;
        Endereco = string.Empty;
        Unidades = new List<Unidade>();
    }

    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Endereco { get; set; }
    public int NumeroUnidades { get; set; }
    public int NumeroBlocos { get; set; }
    public DateTime DataFundacao { get; set; }

    // Relacionamento 1:N com Unidade
    public ICollection<Unidade> Unidades { get; set; }
}
