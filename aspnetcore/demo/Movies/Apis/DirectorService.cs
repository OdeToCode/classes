using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Movies.Protos;

namespace Movies.Apis
{
    public class DirectorService : Movies.Protos.Directors.DirectorsBase
    {
        public override Task<DirectorResult> FetchAllDirectors(
            DirectorRequest request, ServerCallContext context)
        {
            var result = new DirectorResult();
            result.Country = "NL";
            result.Name = "Apollo";
            return Task.FromResult(result);
        }
    }
}
