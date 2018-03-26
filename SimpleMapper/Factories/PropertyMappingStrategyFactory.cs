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
            var attr = matchKey.GetCustomAttribute(typeof(MapToAttribute), false) as MapToAttribute;

            if (attr == null)
                return new ConventionStrategy();
            else
                return new ExplicitStrategy();
        }
    }
}
