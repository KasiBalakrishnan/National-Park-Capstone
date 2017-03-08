using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyDAL surveyDAL;

        public SurveyController(ISurveyDAL surveyDAL)
        {
            this.surveyDAL = surveyDAL;
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", surveyDAL.GetResults());
        }
    }
}