using Microsoft.EntityFrameworkCore;

namespace PharmaFlow.Data;

public class PharmaContext : DbContext
{
    public PharmaContext(DbContextOptions<PharmaContext> options) : base(options) {}

    public DbSet<Dummy> Dummys { get; set; }
}

public class Dummy
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
