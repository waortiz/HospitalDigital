using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ContextoHospitalDigital : DbContext
    {
        public ContextoHospitalDigital() : base("HospitalDigitalEsperanza")
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoDocumento>()
                .HasMany(e => e.Pacientes)
                .WithRequired(e => e.TipoDocumento)
                .HasForeignKey(e => e.IdTipoDocumento)
                .WillCascadeOnDelete(false);
        }
    }
}
