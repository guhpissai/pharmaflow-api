using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class MedicamentoUpdateDto
{
    [Required(ErrorMessage = "O nome do medicamento é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome pode ter no maximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo FornecedorId é obrigatório.")]
    public int FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }
}
