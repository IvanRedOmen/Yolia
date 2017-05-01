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

        public YoliaEntities()
            :base(Properties.Settings.Default.connectionString.ToString())
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention, the generated tables  
            // will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
