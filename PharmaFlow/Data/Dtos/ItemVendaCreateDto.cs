using System.ComponentModel.DataAnnotations;

namespace PharmaFlow.Data.Dtos
{
    public class ItemVendaCreateDto
    {
        [Required(ErrorMessage ="O campo MedicamentoId é obrigatório.")]
        public int MedicamentoId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1.")]
        public int Quantidade { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }
    }
}
