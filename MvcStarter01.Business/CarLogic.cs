using MvcStarter01.DataAccess;
using MvcStarter01.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStarter01.Business
{
    public class CarLogic
    {
        MyContext _context = null;
        public CarLogic()
        {
            _context = new MyContext();
        }

        public List<Car> GetListAll()
        {
            var req = new Repository<Car>(_context);
            return req.GetQuery().ToList();
        }

        public Car GetById(int id)
        {
            var req = new Repository<Car>(_context);
            return req.Single(c => c.Id == id);
        }

        public CarLogic(MyContext context)
        {
            _context = context;
        }
    }
}
