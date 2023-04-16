using CondoNexus.Business.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CondoNexus.API.DTOs;

public class UnidadeDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public string Numero { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, int.MaxValue, ErrorMessage = "O campo {0} precisa ser maior ou igual a {1}")]
    public int Andar { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public string Bloco { get; set; }

    public StatusResidencial StatusResidencial { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Condomínio")]
    public Guid CondominioId { get; set; }

    public CondominioDTO? Condominio { get; set; }

    public ICollection<MoradorDTO> Moradores { get; set; }

    public ICollection<VeiculoDTO> Veiculos { get; set; }
}
