using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IParkDAL parkDAL;

        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", parkDAL.GetParks());
        }

        [HttpGet]
        public ActionResult Park(string id)
        {
            if (id == "true" || id == "false")
            {
                Session["TempIsF"] = Convert.ToBoolean(id);
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                if(Session["TempIsF"] == null)
                {
                    Session["TempIsF"] = Convert.ToBoolean("true");
                }
                return View("Park", parkDAL.GetPark(id));
            }
        }
    }
}
