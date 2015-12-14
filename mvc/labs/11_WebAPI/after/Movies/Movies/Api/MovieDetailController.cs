using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Movies.Infrastructure;
using Movies.Models;

namespace Movies.Api
{
    public class MovieDetailController : ApiController
    {
        public MovieDetailModel GetDetail(int id)
        {
            var db = new MovieData();
            var movie = db.Movies.Find(id);                        
            var model = new MovieDetailModel(movie);
            return model;
        }
    }
}
