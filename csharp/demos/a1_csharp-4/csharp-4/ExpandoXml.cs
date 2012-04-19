using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace csharp_4
{
    public static class ExpandoXml
    {
        public static dynamic AsExpando(this XDocument document)
        {
            return CreateExpando(document.Root);            
        }

        private static dynamic CreateExpando(XElement element)
        {
            var result = new ExpandoObject() as IDictionary<string, object>;
            if(element.Elements().Any(e=>e.HasElements))
            {
                var list = new List<ExpandoObject>();
                result.Add(element.Name.ToString(), list);
                foreach(var childElement in element.Elements())
                {
                    list.Add(CreateExpando(childElement));                       
                }
            }
            else
            {
                foreach(var leafElement in element.Elements())
                {
                    result.Add(leafElement.Name.ToString(), leafElement.Value);
                }
            }

            return result;
        }

        private static IEnumerable<IGrouping<XName, XElement>> ElementGroups(this XElement element)
        {
            return element.Elements().GroupBy(e => e.Name).ToList();
        }
    }
}