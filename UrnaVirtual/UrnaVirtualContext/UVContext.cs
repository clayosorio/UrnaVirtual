using Microsoft.EntityFrameworkCore;
using UrnaVirtual.Modelos;

namespace UrnaVirtual.UrnaVirtualContext
{
    public class UVContext : DbContext
    {

        public DbSet<Vote> Votes { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Aspirant> Aspirants { get; set; }

        public UVContext(DbContextOptions<UVContext> options) : base(options) { }
    }
}
