using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleMapper.PropertyMappingStrategies
{
    public interface IPropertyMappingStrategy
    {
        PropertyInfo Match(IEnumerable<PropertyInfo> matchList, PropertyInfo matchKey);
    }
}
