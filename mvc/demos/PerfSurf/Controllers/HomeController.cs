using System;
using System.Web.Mvc;

namespace PerfSurf.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {            
            return View();
        }    
        
        public ViewResult Time()
        {
            return View();
        }

        public ContentResult ServerTime()
        {
            return Content(DateTime.Now.ToLongTimeString());
        }
    }
}
