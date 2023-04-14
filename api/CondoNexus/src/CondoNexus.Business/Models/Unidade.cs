namespace CondoNexus.Business.Models;

/// <summary>
/// Representa uma unidade residencial em um condomínio.
/// </summary>
public class Unidade : BaseEntity
{
    public Unidade()
    {
        Numero = string.Empty;
        Bloco = string.Empty;
        Moradores = new List<Morador>();
        Veiculos = new List<Veiculo>();
    }

    public string Numero { get; set; }
    public int Andar { get; set; }
    public string Bloco { get; set; }
    public StatusResidencial StatusResidencial { get; set; }
    public Guid CondominioId { get; set; }

    // Relacionamento N:1 com Condomínio
    public Condominio? Condominio { get; set; }

    // Relacionamento 1:N com Morador
    public ICollection<Morador> Moradores { get; set; }

    // Relacionamento 1:N com Veículo
    public ICollection<Veiculo> Veiculos { get; set; }
}
