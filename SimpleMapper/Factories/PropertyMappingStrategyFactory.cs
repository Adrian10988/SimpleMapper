using SimpleMapper.Attributes;
using SimpleMapper.PropertyMappingStrategies;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleMapper.Factories
{
    public class PropertyMappingStrategyFactory : IPropertyMappingStrategyFactory
    {
        public IPropertyMappingStrategy Create(PropertyInfo matchKey)
        {
            var attr = matchKey.GetCustomAttribute(typeof(MapFromAttribute), false) as MapFromAttribute;

            if (attr == null)
                return new ConventionStrategy();
            else
                return new ExplicitStrategy();
        }
    }
}
