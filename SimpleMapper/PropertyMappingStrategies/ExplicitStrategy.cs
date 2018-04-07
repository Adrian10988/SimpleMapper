using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper.PropertyMappingStrategies
{
    public class ExplicitStrategy : IPropertyMappingStrategy
    {
        public PropertyInfo Match(IEnumerable<PropertyInfo> matchList, PropertyInfo matchKey)
        {
            var attr = matchKey.GetCustomAttribute(typeof(MapFromAttribute), false) as MapFromAttribute;

            if (attr == null)
                return null;

            return matchList.FirstOrDefault(a => a.Name == attr.PropertyName);
        }
    }
}
