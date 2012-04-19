using System.Linq;
using System.Web.Mvc;
using Movies.Models;
using MvcContrib.Pagination;

namespace Movies.Controllers
{    
    public class MovieController : Controller
    {
        public MovieController()
        {
            _context = new MovieContext();
        }

        public MovieController(IDbContext context)
        {
            _context = context;
        }

        [OutputCache(CacheProfile = "Regular", VaryByParam = "page")]   
        public ViewResult Index(int? page)
        {
            var model = _context.Movies
                                .OrderByDescending(m => m.ReleaseDate)
                                .AsPagination(page ?? 1);
            return View(model);
        }

        public ViewResult Details(int id)
        {
            var model = _context.Movies.First(m => m.ID == id);
            return View(model);
        }

        public JsonResult QuickDetails(int id)
        {
            var detail =
                _context.Movies
                        .Where(m => m.ID == id)
                        .Select(m => new
                        {
                            AverageReview =
                               m.Reviews.Average(r => r.Rating),
                            TotalReviews = m.Reviews.Count
                        })
                        .Single();

            return Json(detail, JsonRequestBehavior.AllowGet);
        }


        private IDbContext _context;
    }



    //public ActionResult QuickDetails(int id)
    //    {
    //        var ctx = new MovieContext();
    //        var detail =
    //            ctx.Movies
    //               .Where(m => m.ID == id)
    //               .Select(m => new
    //               {
    //                   AverageReview = m.Reviews.Average(r => r.Rating),
    //                   TotalReviews = m.Reviews.Count
    //               })
    //               .Single();

    //        return Json(detail, JsonRequestBehavior.AllowGet);
    //    }


    //    public ActionResult Index()
    //    {
    //        var ctx = new MovieContext();
    //        var movies = ctx.Movies
    //                        .OrderByDescending(m => m.ReleaseDate)
    //                        .Take(25);
    //        return View(movies);
    //    }

    //    public ActionResult Details(int id)
    //    {
    //        var ctx = new MovieContext();
    //        var movie = ctx.Movies
    //                       .Include("Reviews")
    //                       .Where(m => m.ID == id)
    //                       .First();
    //        return View(movie);
    //    }
}
