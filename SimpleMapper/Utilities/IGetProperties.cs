using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleMapper.Utilities
{
    public interface IGetProperties
    {
        IEnumerable<PropertyInfo> Get(Type t);
    }
}