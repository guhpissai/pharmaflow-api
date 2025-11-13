using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Data.Dtos;

public class VendaSearchDto
{
    public int Id { get; set; }
    public DateTime DataVenda { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public decimal Total => Itens.Sum(i => i.Subtotal);
    public List<ItemVendaSearchDto> Itens { get; set; } = new();
}