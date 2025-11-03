using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Data.Dtos;

public class VendaSearchDto
{
    public int Id { get; set; }
    public DateTime DataVenda { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
}
