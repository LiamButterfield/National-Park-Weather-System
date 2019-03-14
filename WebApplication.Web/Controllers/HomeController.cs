using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDao;
        private IWeatherDAO weatherDao;
        public HomeController(IParkDAO parkDao, IWeatherDAO weatherDao)
        {
            this.parkDao = parkDao;
            this.weatherDao = weatherDao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Park> model = parkDao.GetAllParks();
            return View(model);
        }    
        
        [HttpGet]
        public IActionResult ParkDetail(string id)
        {
            Park park = parkDao.GetParkDetails(id);
            park.Weathers = weatherDao.GetForecast(id);
            return View(park);
        }

        //[HttpPost]
        //public void 


        //public void AddToChoice(Weather p)

            //[HttpPost]
            ///redirects you to the temperature you want if C saves to celsius if F saves in farehnheit

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
