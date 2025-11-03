using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Data.Dtos;

public class VendaCreateDto
{
    public int Id { get; set; }

    [Required(ErrorMessage ="O campo ClientId é obrigatório.")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "A venda deve conter ao menos um item.")]
    [MinLength(1, ErrorMessage = "A venda deve conter pelo menos um item.")]
    public ICollection<ItemVendaCreateDto> Items { get; set; } = new List<ItemVendaCreateDto>();
}
