using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Movies.Tests.Fakes
{
    public class FakeObjectSet<T> : IObjectSet<T> where T:class
    {
        public FakeObjectSet()
            :this(Enumerable.Empty<T>())
        {            
        }

        public FakeObjectSet(IEnumerable<T> items)
        {            
            _set = new HashSet<T>();

            foreach(var item in items)
            {
                _set.Add(item);
            }

            _queryableSet = _set.AsQueryable();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        public Expression Expression
        {
            get { return _queryableSet.Expression; }
        }

        public Type ElementType
        {
            get { return _queryableSet.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _queryableSet.Provider; }
        }

        public void AddObject(T entity)
        {
            _set.Add(entity);
        }

        public void Attach(T entity)
        {
            _set.Add(entity);
        }

        public void DeleteObject(T entity)
        {
            _set.Remove(entity);
        }

        public void Detach(T entity)
        {
            _set.Remove(entity);
        }

        private HashSet<T> _set;
        private IQueryable<T> _queryableSet;
    }
}
