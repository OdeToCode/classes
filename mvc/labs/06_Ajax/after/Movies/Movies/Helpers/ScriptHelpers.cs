using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Helpers
{
    public static class ScriptHelpers
    {
        public static MvcHtmlString Script(this HtmlHelper helper, string name)
        {
            var tag = new TagBuilder("script");

            tag.MergeAttribute("src", VirtualPathUtility.ToAbsolute("~/Scripts/" + name));
            tag.MergeAttribute("type", "text/javascript");
            return MvcHtmlString.Create(tag.ToString());
        }

    }
}