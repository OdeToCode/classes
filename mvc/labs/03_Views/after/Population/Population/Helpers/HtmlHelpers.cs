using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Population.Helpers
{
    public static class HtmlHelpers
    {
        public static string Number(this HtmlHelper helper,
                                    double value)
        {
            return value.ToString("N0");
        }
    }

}