using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Models;

public class Venda
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime DataVenda { get; set; } = DateTime.Now;

    [Required]
    public int ClienteId { get; set; }

    [ForeignKey(nameof(ClienteId))]
    public Cliente Cliente { get; set; } = null!;

    public ICollection<ItemVenda> Items { get; set; } = new List<ItemVenda>();

    [NotMapped]
    public decimal Total => Items.Sum(i => i.Quantidade * i.PrecoUnitario);
}