using System.Linq;
using System.Web.Mvc;
using BeyondQueries.Domain;
using BeyondQueries.Models.Data;

namespace BeyondQueries.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
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
