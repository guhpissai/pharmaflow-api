using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class MedicamentoSearchDto
{
    public string Nome { get; set; }

    public int FornecedorId { get; set; }

    public decimal Preco { get; set; }
}
