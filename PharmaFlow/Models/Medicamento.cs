using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Models;

public class Medicamento
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="O nome do medicamento é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome pode ter no maximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required]
    public int FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    public ICollection<ItemVenda> Items { get; set; }
}
