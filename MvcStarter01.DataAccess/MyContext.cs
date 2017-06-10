using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using MvcStarter01.DataAccess.Entity;

namespace MvcStarter01.DataAccess
{
    public class MyContext:DbContext
    {
        public MyContext() : base(ConfigurationManager.ConnectionStrings["CarDb"].ToString())
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<TypeNameForeignKeyDiscoveryConvention>();
            modelBuilder.Conventions.Remove<NavigationPropertyNameForeignKeyDiscoveryConvention>();

            modelBuilder.Configurations.Add(new DriverConfig());
            modelBuilder.Configurations.Add(new CarConfig());
            modelBuilder.Configurations.Add(new FuelTrackerConfig());
        }
    }
}
