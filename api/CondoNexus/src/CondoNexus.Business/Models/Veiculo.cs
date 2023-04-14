namespace CondoNexus.Business.Models;

/// <summary>
/// Representa um veículo pertencente a uma unidade residencial.
/// </summary>
public class Veiculo : BaseEntity
{
    public Veiculo()
    {
        Placa = string.Empty;
        Marca = string.Empty;
        Modelo = string.Empty;
        Cor = string.Empty;
    }

    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }
    public Guid UnidadeId { get; set; }

    // Relacionamento N:1 com Unidade
    public Unidade? Unidade { get; set; }
}
