using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    internal static class Constants
    {
        static internal readonly List<Type> TypeWhiteList;

        static Constants()
        {
            TypeWhiteList = new List<Type>()
            {
                typeof(short),
                typeof(string),
            typeof(int),
            typeof(long),
            typeof(double),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime),
            typeof(TimeSpan),
            typeof(short?),
            typeof(int?),
            typeof(long?),
            typeof(double?),
            typeof(decimal?),
            typeof(bool?),
            typeof(DateTime?),
            typeof(TimeSpan?)
            };
        }
    }
}
