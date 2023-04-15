using System.ComponentModel.DataAnnotations;

namespace CondoNexus.API.DTOs;

public class CondominioDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 14)]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ser maior que {1}")]
    public int NumeroUnidades { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ser maior que {1}")]
    public int NumeroBlocos { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ser maior que {1}")]
    public int NumeroAndares { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime DataFundacao { get; set; }

    public IEnumerable<UnidadeDTO> Unidades { get; set; }

    public EnderecoDTO Endereco { get; set; }
}
