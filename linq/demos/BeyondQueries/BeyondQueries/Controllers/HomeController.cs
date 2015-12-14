using System;
using System.Linq;
using System.Web.Mvc;
using BeyondQueries.Domain;
using BeyondQueries.Models.Data;

namespace BeyondQueries.Controllers
{
    public static class MyTimeExtensions
    {
        public static TimeSpan Minutes(this int minutes)
        {
            return new TimeSpan(0, 0, minutes, 0);
        }

        public static DateTime Ago(this TimeSpan span)
        {
            return DateTime.Now - span;
        }

    }



    [HandleError]
    public class HomeController : Controller
    {
        public void Test()
        {
            var time = 2.Minutes().Ago();


        }



        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EvaluateMovie(Movie movie)
        {
            var flowchart = MovieFlowchart.Create();

            var result = flowchart.Evaluate(movie);

            return Json(new
            {
                result = result.Result,
                required = result.RequiredFields.Select(f => f.PropertyName)
            });
        }
    }
}
