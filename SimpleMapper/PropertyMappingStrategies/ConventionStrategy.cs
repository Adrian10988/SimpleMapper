using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper.PropertyMappingStrategies
{
    public class ConventionStrategy : IPropertyMappingStrategy
    {
        public PropertyInfo Match(IEnumerable<PropertyInfo> matchList, PropertyInfo matchKey)
        {
            return matchList.FirstOrDefault(a => a.Name == matchKey.Name);
        }
    }
}
