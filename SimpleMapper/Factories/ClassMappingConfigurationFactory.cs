using ShipBob.Mapper.Attributes;
using ShipBob.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMapper.Factories
{
    public class ClassMappingConfigurationFactory : IClassMappingConfigurationFactory
    {
        public ClassMappingConfiguration Create(Type t)
        {
            var config = new ClassMappingConfiguration();
            var attributes = t.GetCustomAttributes(true).ToList();
            config.ConvertPrimitives = attributes.Any(a => a is ImplicitlyConvertPrimitives);
            config.RejectNullReferences = attributes.Any(a => a is RejectNullReferencesAttribute);
            config.RequireAllProperties = attributes.Any(a => a is RequireAllPropertiesAttribute);

            return config;
        }
    }
}
