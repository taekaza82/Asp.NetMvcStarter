using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStarter01.DataAccess.Entity
{
    public class FuelTracker
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public double FuelBefore { get; set; }
        public double FuelAfter { get; set; }
        public double FuelAmount { get; set; }
        public DateTime FuelDate { get; set; }
    }

    public class FuelTrackerConfig : EntityTypeConfiguration<FuelTracker>
    {
        public FuelTrackerConfig()
        {
            ToTable("FuelTracker");
            Property(c => c.Id).HasColumnName("TrackerId");
            Property(c => c.CarId).HasColumnName("CarId");
            Property(c => c.FuelAfter).HasColumnName("FuelAfter");
            Property(c => c.FuelAmount).HasColumnName("FuelAmount");
            Property(c => c.FuelBefore).HasColumnName("FuelBefore");
            Property(c => c.FuelDate).HasColumnName("FuelDate");

            HasKey(c => c.Id);
        }
    }
}
