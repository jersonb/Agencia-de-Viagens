using Microsoft.EntityFrameworkCore;
using WebAppMvcVda.Models;

namespace WebAppMvcVda.Contexts
{
    public class VdaContext : DbContext
    {
        public VdaContext(DbContextOptions<VdaContext> options) : base(options)
        {
        }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Andeiro> Andeiros { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }

    }
}
