using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;

namespace CoreMeasures.V30.Model
{
    public class PropertySpecifier<T>
    {
        public PropertySpecifier(Expression<Func<T, object>> expression)
        {
            Expression = expression;
            _getter = expression.Compile();
            
            // ksa todo : DynamicMethod instead?
            _setHelper = (PropertyInfo)((MemberExpression)Expression.Body).Member;
            _setter = (o, v) => _setHelper.SetValue(o, v, null);                                 
        }

        public Expression<Func<T, object>> Expression { get; private set; }
      
        public string PropertyName 
        {
            get
            {
                MemberExpression me = Expression.Body as MemberExpression;
                if (me == null)
                {
                    throw new InvalidOperationException(Expression.ToString() + " is not a member expression");
                }
                return me.Member.Name;
            }        
        }

        public V GetValue<V>(T source)
        {
            return (V)_getter(source);
        }

        public object GetValue(T source)
        {
            return _getter(source);
        }

        public void SetValue(T source, object value)
        {
            _setter(source, value);
        }

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

        Func<T, object> _getter;
        Action<T, object> _setter;
        PropertyInfo _setHelper;

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
