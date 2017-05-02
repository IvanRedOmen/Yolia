using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Model
{
    public class YoliaEntities: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        public YoliaEntities()
            :base(Properties.Settings.Default.connectionString.ToString())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Servicio>()
                .HasKey(e => e.FolioServicio);

            modelBuilder.Entity<Servicio>()
                        .HasRequired(s => s.Pago)
                        .WithRequiredPrincipal(ad => ad.Servicio);
        }
    }
}
