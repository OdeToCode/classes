using System;
using BeyondQueries.Domain.BuilderExtensions;
using BeyondQueries.Models.Data;

namespace BeyondQueries.Domain
{
    public class MovieFlowchart : Flowchart<Movie, MovieResult>
    {
        public static MovieFlowchart Create()
        {
            var chart = new MovieFlowchart();
                    
                chart.WithShape("CheckTitle")                        
                        .RequiresField(m=>m.Title)
                        .WithArrowPointingTo("CheckLength")
                            .AndTheRule(m => !String.IsNullOrEmpty(m.Title))

                    .WithShape("CheckLength")
                        .RequiresField(m => m.Length)
                        .WithArrowPointingTo("BadMovie")
                            .AndTheRule(m => m.Length > 120)
                        .WithArrowPointingTo("GoodMovie")
                            .AndTheRule(m => m.Length == 75)
                        .WithArrowPointingTo("CheckReleaseDate")
                            .AndTheRule(m => m.Length.HasValue)                

                    .WithShape("CheckReleaseDate")
                        .RequiresField(m => m.ReleaseDate)
                        .WithArrowPointingTo("BadMovie")
                            .AndTheRule(m => m.ReleaseDate.HasValue &&
                                             m.ReleaseDate.Value.Year < 2000)
                        .WithArrowPointingTo("GoodMovie")
                            .AndTheRule(m => m.ReleaseDate.HasValue)

                    .WithShape("BadMovie").YieldingResult(MovieResult.BadMovie)
                    .WithShape("GoodMovie").YieldingResult(MovieResult.GoodMovie);

            return chart;
        }
    }
}