using MvcStarter01.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcStarter01.Web.Models
{
    public class CarViewModel
    {
        public List<Car> Cars;
        public int CountOfCars;
    }

    public class Refuel
    {
        public int CarId { get; set; }
        public string FuelBefore { get; set; }
        public string FuelAmount { get; set; }
    }

    public class Result
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}