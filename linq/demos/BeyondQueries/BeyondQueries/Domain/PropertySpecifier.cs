using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeyondQueries.Domain
{
    public class PropertySpecifier<T>
    {
        public PropertySpecifier(Expression<Func<T, object>> expression)
        {
            if(expression.Body is MemberExpression)
            {

				// m => m.Title
                var me = expression.Body as MemberExpression;
                _propertyName = me.Member.Name; 
				// "Title"
            }
            else if(expression.Body is UnaryExpression)
            {				// m => m.Length
                // m => m.Id

                var ue = expression.Body as UnaryExpression;
                var me = ue.Operand as MemberExpression;
                _propertyName = me.Member.Name;
				// "Length"
            }
            
        }

        public string PropertyName
        {
            get
            {

                return _propertyName;
            }
        }

        private string _propertyName;

        public static IEqualityComparer<PropertySpecifier<T>> Comparer
        {
            get
            {
                return new _Comparer();
            }
        }

        public override string ToString()
        {
            return PropertyName;
        }

        private class _Comparer : IEqualityComparer<PropertySpecifier<T>>
        {
            public bool Equals(PropertySpecifier<T> x, PropertySpecifier<T> y)
            {
                return x.PropertyName.Equals(y.PropertyName);
            }

            public int GetHashCode(PropertySpecifier<T> obj)
            {
                return obj.PropertyName.GetHashCode();
            }
        }
    }
}