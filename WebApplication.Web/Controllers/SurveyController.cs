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
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyDao;
        public SurveyController(ISurveyDAO surveyDao)
        {
            this.surveyDao = surveyDao;
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
            return View();
        }
    }
}