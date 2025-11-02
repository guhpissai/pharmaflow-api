using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class ClienteSearchDto
{
    public int Id { get; set; }
    public string RazaoSocial { get; set; }
    public string CNPJ { get; set; }
    public string Email { get; set; }
    public string? Telefone { get; set; }
}
