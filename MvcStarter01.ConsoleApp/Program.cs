using MvcStarter01.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStarter01.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var carLogic = new CarLogic();

            var car = carLogic.GetById(1);

            Console.WriteLine("Brand : " + car.Brand);
            Console.WriteLine("Model : " + car.Model);
            Console.WriteLine("Driver Name : " + car.Driver.FirstName + " " + car.Driver.LastName);
            Console.ReadLine();
        }
    }
}
