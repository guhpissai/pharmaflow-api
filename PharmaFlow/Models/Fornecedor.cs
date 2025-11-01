using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Models;

public class Fornecedor
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A razão social do fornecedor é obrigatória.")]
    [MaxLength(100, ErrorMessage = "A razão social pode ter no máximo 100 caracteres.")]
    public string RazaoSocial { get; set; }

    [Required(ErrorMessage = "O CNPJ do fornecedor é obrigatório.")]
    [MaxLength(14, ErrorMessage = "O CNPJ pode ter no máximo 14 caracteres.")]
    public string CNPJ { get; set; }

    public ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}
