using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

[DataObject]
public class ReflectiveDataSource
{
    public IEnumerable<string> GetAssemblySelections()
    {
        return null;
    }

    public int GetTypesCount(string nameFilter, bool publicOnly)
    {
        return 0;
    }

    public IEnumerable<Type> GetTypes(string nameFilter, bool publicOnly)
    {
        return null;
    }

    public IEnumerable<Type> GetTypes(int maximumRows, int startRowIndex, 
                                      string nameFilter, bool publicOnly)
    {
        return null;
    }

    public TypeStatistics GetTypeStatistics(
            string namefilter, bool publicOnly)
    {
        return null;
    }
}
