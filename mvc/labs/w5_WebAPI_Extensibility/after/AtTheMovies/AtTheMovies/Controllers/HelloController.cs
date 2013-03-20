using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtTheMovies.Controllers
{
    public class HelloController : ApiController
    {
        public string GetMessage()
        {
            return "Hello, World!";
        }

        public string GetMessage(string name)
        {
            return "Hello, " + name + "!";
        }
    }
}
