using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesafioTelzir.BL;
using DesafioTelzir.Models;

namespace DesafioTelzir.Controllers
{
    public class HomeController : Controller
    {
        string filelocationRate = System.Web.HttpContext.Current.Server.MapPath("~/DAO/RatesDataSource.xml");
        string filelocationFaleMais = System.Web.HttpContext.Current.Server.MapPath("~/DAO/FaleMaisDataSource.xml");
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateOriginDropDown()
        {
            RateBL ratebl = new RateBL();
            List<int> rateOrigins = ratebl.getRatesOrigins(filelocationRate);
            return Json(rateOrigins, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PopulateDestinationDropDown(int origin)
        {
            RateBL ratebl = new RateBL();
            List<int> rateDestination = ratebl.getRatesDestinationsByOrigin(origin, filelocationRate);
            return Json(rateDestination, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CalculateRateWithoutFaleMais(string origin, string destination, string minutes)
        {
            RateBL ratebl = new RateBL();
            int origin2 = Convert.ToInt32(origin);
            int destination2 = Convert.ToInt32(destination);
            int minutes2 = !String.IsNullOrEmpty(minutes) ? Convert.ToInt32(minutes) : 0;

            double value = ratebl.getTotalRateWithoutFaleMais(origin2, destination2,
                    minutes2, filelocationRate);

            return Json(String.Format("{0:0.00}", value), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CalculatePriceWithFaleMais(string origin, string destination, string minutes, string falemais)
        {
            RateBL ratebl = new RateBL();
            int origin2 = Convert.ToInt32(origin);
            int destination2 = Convert.ToInt32(destination);
            int minutes2 = !String.IsNullOrEmpty(minutes) ? Convert.ToInt32(minutes) : 0 ;
            int falemais2 = !String.IsNullOrEmpty(falemais) ? Convert.ToInt32(falemais) : 0;

            double value = ratebl.getTotalRateWithFaleMais(origin2, destination2,
                    minutes2, falemais2, filelocationRate, filelocationFaleMais);

            return Json(String.Format("{0:0.00}", value), JsonRequestBehavior.AllowGet);
        }
    }
}
