using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos;

public class ClienteCreateDto
{
    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [StringLength(100, ErrorMessage = "A Razão Social pode ter no maximo 100 caracteres.")]
    public string RazaoSocial { get; set; }

    [Required(ErrorMessage = "O CNPJ do cliente é obrigatório.")]
    [StringLength(14, ErrorMessage = "O CNPJ pode ter no maximo 14 caracteres.")]
    public string CNPJ { get; set; }

    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [StringLength(100, ErrorMessage = "O e-mail pode ter no maximo 100 caracteres.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Telefone inválido.")]
    [StringLength(15)]
    public string? Telefone { get; set; }
}
