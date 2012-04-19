using System;
using System.Collections.Generic;

public class TypeStatistics
{
    public TypeStatistics()
    {

    }

    public TypeStatistics Accumulate(Type t)
    {
        _countOfTypes++;
        _totalClassNameLength += t.Name.Length;
        if (t.Name.Length == _longestClassNameLength)
        {
            _longestClassNames.Add(t.Name);
        }
        else if(t.Name.Length > _longestClassNameLength)
        {
            _longestClassNames.Clear();
            _longestClassNames.Add(t.Name);
            _longestClassNameLength = t.Name.Length;
        }
        return this;
    }

    public TypeStatistics Complete()
    {
        CountOfTypes = _countOfTypes;
        LongestClassNames = String.Join(" ", _longestClassNames.ToArray());
        AverageClassNameLength = (double)_totalClassNameLength / _countOfTypes;
        return this;
    }

    public string LongestClassNames { get; set; }
    public int CountOfTypes { get; set; }
    public double AverageClassNameLength { get; set; }


    int _countOfTypes = 0;
    int _totalClassNameLength = 0;
    int _longestClassNameLength = 0;
    List<string> _longestClassNames = new List<string>();

}
