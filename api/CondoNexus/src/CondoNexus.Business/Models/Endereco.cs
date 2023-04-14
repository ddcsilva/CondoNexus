namespace CondoNexus.Business.Models;

/// <summary>
/// Representa um endereço associado a um condomínio.
/// </summary>
public class Endereco : BaseEntity
{
    public Endereco()
    {
        Logradouro = string.Empty;
        Numero = string.Empty;
        Complemento = string.Empty;
        Cep = string.Empty;
        Bairro = string.Empty;
        Cidade = string.Empty;
        Estado = string.Empty;
    }

    public Guid CondominioId { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Cep { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    // Relacionamento 1:1 com Condomínio
    public Condominio? Condominio { get; set; }
}
