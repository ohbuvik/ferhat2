using Microsoft.EntityFrameworkCore;

public class BrukerContext : DbContext
{
    public BrukerContext(DbContextOptions<BrukerContext> options)
        : base(options) { }

    public DbSet<Bruker> Brukere { get; set; }
}
