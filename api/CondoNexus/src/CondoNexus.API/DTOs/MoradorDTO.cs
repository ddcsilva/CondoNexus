using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CondoNexus.API.DTOs;

public class MoradorDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de e-mail válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    [DisplayName("Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    [DisplayName("Foto do Morador")]
    public string FotoUpload { get; set; }
    
    public string Foto { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Unidade")]
    public Guid UnidadeId { get; set; }

    public UnidadeDTO Unidade { get; set; }
}
