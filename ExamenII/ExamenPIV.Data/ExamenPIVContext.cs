using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ExamenPIV.Data.Modelos;

namespace ExamenPIV.Data
{
    public class ExamenPivContext: DbContext
    {
        public ExamenPivContext()
        {
            Database.SetInitializer(new ExamenDbInitializer());
        }
        public ExamenPivContext(string connectionName):base(connectionName)
        {
            Database.SetInitializer(new ExamenDbInitializer());
        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
