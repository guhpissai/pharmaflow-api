using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Models;

public class Cliente
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="O nome do cliente é obrigatório.")]
    [MaxLength(100, ErrorMessage ="O nome pode ter no maximo 100 caracteres.")]

    public string RazaoSocial { get; set; }

    [Required(ErrorMessage = "O CNPJ do cliente é obrigatório.")]
    [MaxLength(14, ErrorMessage ="O CNPJ pode ter no maximo 14 caracteres.")]
    public string CNPJ { get; set; }

    [EmailAddress(ErrorMessage ="E-mail inválido")]
    [MaxLength(100, ErrorMessage ="O e-mail pode ter no maximo 100 caracteres.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Telefone inválido.")]
    [MaxLength(15)]
    public string? Telefone { get; set; }

    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
}
