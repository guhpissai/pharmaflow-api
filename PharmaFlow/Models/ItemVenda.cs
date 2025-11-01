using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Models;

public class ItemVenda
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VendaId { get; set; }

    [ForeignKey(nameof(VendaId))]
    public Venda Venda { get; set; }

    [Required]
    public int MedicamentoId { get; set; }

    [ForeignKey(nameof(MedicamentoId))]
    public Medicamento Medicamento { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }

    [NotMapped]
    public decimal Subtotal => Quantidade * PrecoUnitario;
}
