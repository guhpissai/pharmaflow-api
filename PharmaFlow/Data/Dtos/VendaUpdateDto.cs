using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class VendaUpdateDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo ClientId é obrigatório.")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "A venda deve conter ao menos um item.")]
    [MinLength(1, ErrorMessage = "A venda deve conter pelo menos um item.")]
    public ICollection<CreateItemVendaDto> Items { get; set; } = new List<CreateItemVendaDto>();
}
