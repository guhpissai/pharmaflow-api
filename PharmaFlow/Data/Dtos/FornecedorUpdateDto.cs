using PharmaFlow.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos
{
    public class FornecedorUpdateDto
    {
        [Required(ErrorMessage = "A razão social do fornecedor é obrigatória.")]
        [StringLength(100, ErrorMessage = "A razão social pode ter no máximo 100 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O CNPJ do fornecedor é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CNPJ pode ter no máximo 14 caracteres.")]
        public string CNPJ { get; set; }
    }
}
