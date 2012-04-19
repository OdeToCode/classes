using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieReviewsModel;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var repository = new MovieRepository();

            var topMovie = (
                     from m in repository.Movies
                     orderby m.Reviews.Average(r => r.Rating) descending
                     select m
                 ).First();

            _topMovie.Text = topMovie.Title;
        }

    }

    protected void UpdateMovie(object sender, EventArgs e)
    {
        var repository = new MovieRepository();
        var movie = repository.Movies
                              .First();
        movie.ReleaseDate = DateTime.Now;
        repository.SaveChanges();
        _movieGrid.DataBind();
    }

    protected void DeleteMovie(object sender, EventArgs e)
    {
        var repository = new MovieRepository();
        var movie = repository.Movies
                       .OrderBy(m => m.MovieID)
                              .Skip(1)
                              .First();
        
        while (movie.Reviews.Count > 0)
        {
            repository.DeleteObject(movie.Reviews.First());
        }
        repository.DeleteObject(movie);
        repository.SaveChanges();
        _movieGrid.DataBind();
    }

    protected void InsertMessage(object sender, EventArgs e)
    {
        Log newLog = new Log();
        newLog.Message = _logMesssage.Text;
        newLog.Time = DateTime.Now;

        var repository = new MovieRepository();
        repository.AddToLogs(newLog);
        repository.SaveChanges();
    }


}
