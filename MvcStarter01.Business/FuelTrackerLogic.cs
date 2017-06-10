using MvcStarter01.DataAccess;
using MvcStarter01.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStarter01.Business
{
    public class FuelTrackerLogic
    {
        MyContext _context = null;
        public FuelTrackerLogic()
        {
            _context = new MyContext();
        }

        public FuelTrackerLogic(MyContext context)
        {
            _context = context;
        }

        public bool SaveRefeul(int id, string beforeFuel, string refuelAmount)
        {
            try
            {
                var req = new Repository<FuelTracker>(_context);                

                var fuelTracker = new FuelTracker()
                {
                    CarId = id,
                    FuelBefore = Convert.ToDouble(beforeFuel),
                    FuelAmount = Convert.ToDouble(refuelAmount),
                    FuelAfter = Convert.ToDouble(beforeFuel) + Convert.ToDouble(refuelAmount),
                    FuelDate = DateTime.Now
                };

                req.Add(fuelTracker);
                req.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
