using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class MedicamentoSearchDto
{
    public string Nome { get; set; }
    public int FornecedorId { get; set; }
    public string FornecedorNome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
