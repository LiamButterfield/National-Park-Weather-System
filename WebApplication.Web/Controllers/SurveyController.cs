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
    /// <summary>
    /// Includes views of survey form and results
    /// </summary>
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyDao;
        private IParkDAO parkDao;
        public SurveyController(ISurveyDAO surveyDao, IParkDAO parkDao)
        {
            this.surveyDao = surveyDao;
            this.parkDao = parkDao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Survey survey)
        {
            if (ModelState.IsValid)
            {
                surveyDao.CreateSurvey(survey);
                TempData["PostSuccessful"] = "Your post was successful!";
                return RedirectToAction("FavoritePark");
            }
            else
            {
                return View(survey);
            }
        }

        public IActionResult FavoritePark()
        {
            IList<SurveyResult> surveys = surveyDao.Results();
            return View(surveys);
        }
    }
}