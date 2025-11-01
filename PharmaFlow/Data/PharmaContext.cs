using Microsoft.EntityFrameworkCore;
using PharmaFlow.Models;

namespace PharmaFlow.Data;

public class PharmaContext : DbContext
{
    public PharmaContext(DbContextOptions<PharmaContext> options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<ItemVenda> ItemVendas { get; set; }

}
