using AutoMapper;
using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaFlow.Data.Dtos;

public class ItemVendaSearchDto : Profile
{
    public int MedicamentoId { get; set; }
    public string MedicamentoNome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Subtotal => Quantidade * PrecoUnitario;
}
