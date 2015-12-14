using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Linq;

namespace a1_csharp_4
{
    public class DynamicXml : DynamicObject, IEnumerable
    {
        public static dynamic Parse(string xml)
        {
            return new DynamicXml(XDocument.Parse(xml));            
        }

        public DynamicXml(dynamic xElement)
        {
            this.xml = xElement;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if(xml.Element(binder.Name) != null)
            {
                result = new DynamicXml(xml.Element(binder.Name));
                return true;   
            }
            else if(xml.Attribute(binder.Name) != null)
            {
                result = xml.Attribute(binder.Name).Value;
                return true;
            }
            result = null;
            return false;            
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in xml.Elements())
            {
                yield return new DynamicXml(element);
            }
        }

        private dynamic xml;
    }
}