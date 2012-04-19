using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;

[DataObject]
public class ReflectiveDataSource
{
    public IEnumerable<string> GetAssemblySelections()
    {
        return Enumerable.Repeat("All", 1)
                         .Concat(Assembly.GetExecutingAssembly()
                                         .GetReferencedAssemblies()                                         
                                         .Select(aname => aname.Name)
                                         .OrderBy(s => s));
    }

    public int GetTypesCount(string nameFilter, bool publicOnly)
    {
        return GetTypes(nameFilter, publicOnly).Count();
    }

    public IEnumerable<Type> GetTypes(string nameFilter, bool publicOnly)
    {
        return
            Assembly.GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Where(aname => String.IsNullOrEmpty(nameFilter) || nameFilter.ToLower() == "all" || aname.Name == nameFilter)
                    .Select(aname => Assembly.Load(aname.FullName))
                    .SelectMany(asm => asm.GetTypes())
                    .Where(t => !publicOnly || t.IsPublic);
    }

    public IEnumerable<Type> GetTypes(int maximumRows, int startRowIndex, string nameFilter, bool publicOnly)
    {
        return GetTypes(nameFilter, publicOnly).Skip(startRowIndex).Take(maximumRows);
    }

    public TypeStatistics GetTypeStatistics(string namefilter, bool publicOnly)
    {
        return GetTypes(namefilter, publicOnly)
                    .Aggregate(new TypeStatistics(),
                               (acc, t) => acc.Accumulate(t), 
                               acc => acc.Complete());
    }
}
