using Microsoft.EntityFrameworkCore;
using Models;


namespace Repository
{
    public class GestranContext : DbContext
    {
        public GestranContext() { }        

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<ItemInspecao> ItensInspecao { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }        
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItens { get; set; }
        public GestranContext(DbContextOptions<GestranContext> options) : base(options) { }
    }

}
