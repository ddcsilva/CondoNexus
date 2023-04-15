using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CondoNexus.API.DTOs;

public class VeiculoDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(7, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 7)]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public string Cor { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1900, int.MaxValue, ErrorMessage = "O campo {0} precisa ser maior ou igual a {1}")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Unidade")]
    public Guid UnidadeId { get; set; }

    public UnidadeDTO Unidade { get; set; }
}
