using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStarter01.DataAccess.Entity
{
    public class Car
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegisterNo { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
    }

    public class CarConfig : EntityTypeConfiguration<Car>
    {
        public CarConfig()
        {
            ToTable("Car");
            Property(c => c.Id).HasColumnName("CarId");
            Property(c => c.Brand).HasColumnName("Brand");
            Property(c => c.Model).HasColumnName("Model");
            Property(c => c.DriverId).HasColumnName("DriverId");
            Property(c => c.RegisterNo).HasColumnName("CarRegisterNo");
            Property(c => c.Color).HasColumnName("Color");
            Property(c => c.Mileage).HasColumnName("Milage");

            HasKey(c => c.Id);
            HasRequired(c => c.Driver).WithMany().HasForeignKey(c => c.DriverId);
        }
    }
}
