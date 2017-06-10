using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStarter01.DataAccess.Entity
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string LicenseNo { get; set; }        
    }

    public class DriverConfig : EntityTypeConfiguration<Driver>
    {
        public DriverConfig()
        {
            ToTable("Driver");
            Property(c => c.Id).HasColumnName("DriverId");
            Property(c => c.FirstName).HasColumnName("FirstName");
            Property(c => c.LastName).HasColumnName("LastName");
            Property(c => c.Age).HasColumnName("Age");
            Property(c => c.LicenseNo).HasColumnName("DriverLicenseNo");

            HasKey(c => c.Id);           
        }
    }
}
