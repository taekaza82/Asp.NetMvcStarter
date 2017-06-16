using MvcStarter01.Business;
using MvcStarter01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStarter01.Web.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var carLogic = new CarLogic();

            var carList = carLogic.GetListAll();

            var model = new CarViewModel()
            {
                Cars = carList,
                CountOfCars = carList.Count
            };

            return View(model);
        }

        public ActionResult Refuel(int id)
        {
            var carLogic = new CarLogic();

            var car = carLogic.GetById(id);

            return View(car);
        }

        [HttpPost]
        public ActionResult Refuel(int id, string beforeFuel, string refuelAmount)
        {
            var fuelTrackerLogic = new FuelTrackerLogic();

            var result = fuelTrackerLogic.SaveRefeul(id, beforeFuel, refuelAmount);

            if (result == true)
                return RedirectToAction("Index");
            else
            {
                var carLogic = new CarLogic();
                var car = carLogic.GetById(id);
                ViewBag.Message = "Cannot Save Refuel!!";
                return View(car);
            }
        }

        [HttpPost]
        public JsonResult SaveFuel(Refuel refuel)
        {
            var fuelTrackerLogic = new FuelTrackerLogic();

            var saveResult = fuelTrackerLogic.SaveRefeul(refuel.CarId, refuel.FuelBefore, refuel.FuelAmount);

            var result = new Result();
            if (saveResult == true)
            {
                result.Status = "SUCCESS";
                result.Message = "Save Complete.";
            }
            else
            {
                result.Status = "FAILED";
                result.Message = "Save Failed, please try again.";
            }

            return Json(new
            {
                Result = result
            }, JsonRequestBehavior.AllowGet);              
           
        }

    }
}