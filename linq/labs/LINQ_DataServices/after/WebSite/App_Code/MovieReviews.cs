using System;
using System.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using MovieReviewModel;
using System.Linq.Expressions;


[System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class MovieReviews : DataService<MovieRepository>
{
    public static void InitializeService(IDataServiceConfiguration config)
    {
        config.UseVerboseErrors = true; 
        config.SetEntitySetAccessRule("Movies", 
                EntitySetRights.AllRead);        
        config.SetEntitySetAccessRule("Reviews",
                 EntitySetRights.All);
        config.MaxResultsPerCollection = 20;
        config.SetServiceOperationAccessRule("GetTopTenMovies", 
            ServiceOperationRights.All);
    }

    [WebGet]
    public IQueryable<Movie> GetTopTenMovies(int year)
    {
        var query =  
                from m in CurrentDataSource.Movies 
                where m.ReleaseDate.Year == year
                orderby m.Reviews.Average(r => r.Rating) descending 
                select m;
        return query.Take(10);
    }

    [QueryInterceptor("Movies")]
    public Expression<Func<Movie, bool>> MovieYearInteceptor()
    {
        return m => m.ReleaseDate.Year >= 2007;
    }

    
}
