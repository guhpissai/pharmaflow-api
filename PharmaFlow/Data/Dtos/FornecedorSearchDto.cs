using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class FornecedorSearchDto
{
    public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string CNPJ { get; set; }
    public ICollection<MedicamentoSearchDto> Medicamentos { get; set; } = new List<MedicamentoSearchDto>();
}
