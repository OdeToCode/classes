using System;
using System.Linq;
using Pluralsight.Linq;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _stats = new PopulationStatistics();
            BindHighestMalePopulations();
            BindLowestTotalPopulations();
            BindFemalePopulationIncrease();
        }
    }

    private void BindHighestMalePopulations()
    {
        //var query =
        //    from m in _stats.Males
        //    where m.Year == 2002
        //    orderby m.Population descending
        //    select m;

        var query = _stats.Males
                          .Where(m => m.Year == 2002)
                          .OrderByDescending(m => m.Population);

        _malePopulation.DataSource = query.Take(10);
        _malePopulation.DataBind();
    }

    private void BindLowestTotalPopulations()
    {
        //unoptimized
        //var query =
        //    from m in _stats.Males
        //    join f in _stats.Females
        //         on new { m.Country, m.Year } equals new { f.Country, f.Year }
        //    where m.Year == 2002
        //    orderby m.Population + f.Population ascending
        //    select new
        //    {
        //        Country = m.Country, 
        //        Males = m.Population,
        //        Females = f.Population,
        //        Total = m.Population + f.Population
        //    };

        //var query =
        //    from m in _stats.Males.Where(m => m.Year == 2002)
        //    join f in _stats.Females.Where(f => f.Year == 2002)
        //         on m.Country equals f.Country
        //    let totalPopulation = m.Population + f.Population
        //    orderby totalPopulation ascending
        //    select new
        //    {
        //        Country = m.Country,
        //        Males = m.Population,
        //        Females = f.Population,
        //        Total = totalPopulation
        //    };

        var query =
            _stats.Males.Where(m => m.Year == 2002)
                  .Join(_stats.Females.Where(f => f.Year == 2002),
                        m => m.Country,
                        f => f.Country,
                        (m, f) => new { Country = m.Country, 
                                        Males = m.Population,
                                        Females = f.Population,
                                        TotalPopulation = m.Population +
                                                          f.Population})
                  .OrderBy(g => g.TotalPopulation);
        
        _lowestTotalPopulation.DataSource = query.Take(10);
        _lowestTotalPopulation.DataBind();
    }

    private void BindFemalePopulationIncrease()
    {
        //var query =
        //    from f in _stats.Females
        //    from p in (from p in _stats.Females 
        //               where p.Country == f.Country &&
        //                     p.Year == f.Year -1
        //               select p)
        //    let delta = f.Population - p.Population
        //    orderby delta descending 
        //    select new 
        //    {
        //        f.Country,
        //        f.Year,
        //        f.Population, 
        //        Change = delta
        //    };

        var query =
            _stats.Females
                  .SelectMany(f => _stats.Females
                                         .Where(p => p.Country == f.Country &&
                                                     p.Year == f.Year - 1)
                                         .Select(p => new {
                                                    f.Country,
                                                    f.Year,
                                                    f.Population,
                                                    Change = f.Population -
                                                             p.Population
                                                    }))
                 .OrderByDescending(f => f.Change);
      
        _percentIncrease.DataSource = query.Take(10);
        _percentIncrease.DataBind();

    }

    protected PopulationStatistics _stats = new PopulationStatistics();

    
}
