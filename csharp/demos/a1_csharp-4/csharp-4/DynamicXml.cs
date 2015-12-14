using System;
using System.Collections;
using System.Dynamic;
using System.Xml.Linq;

namespace csharp_4
{
    public class DynamicXml : DynamicObject, IEnumerable
    {
        public DynamicXml(string fileName)
        {
            _xml = XDocument.Load(fileName);
        }

        public DynamicXml(dynamic xml)
        {
            _xml = xml;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var newXml = _xml.Element(binder.Name);
            result = new DynamicXml(newXml);
            return newXml != null;
        }

        public static implicit operator string(DynamicXml xml)
        {
            return xml._xml.Value;
        }

        public IEnumerator GetEnumerator()
        {            
            foreach(var child in _xml.Elements())
            {
                yield return new DynamicXml(child);
            }
        }

        private dynamic _xml;        
    }
}