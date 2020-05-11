using SimpleMapper.Attributes;
using SimpleMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMapper.Factories
{
    public class ClassMappingConfigurationFactory : IClassMappingConfigurationFactory
    {
        public ClassMappingConfiguration Create(Type source, Type destination)
        {
            var config = new ClassMappingConfiguration();
            var sourceAttributes = source.GetCustomAttributes(true).ToList();
            var destinationAttributes = destination.GetCustomAttributes(true).ToList();
            var attributes = new List<object>();
            attributes.AddRange(sourceAttributes);
            attributes.AddRange(destinationAttributes);

            config.ConvertPrimitives = attributes.Any(a => a is ImplicitConversionAttribute);
            config.RejectNullReferences = destinationAttributes.Any(a => a is RejectNullReferencesAttribute);
            config.RequireAllProperties = destinationAttributes.Any(a => a is RequireAllPropertiesAttribute);

            return config;
        }

        public ClassMappingConfiguration Create(Type t)
        {
            var config = new ClassMappingConfiguration();
            var attributes = t.GetCustomAttributes(true).ToList();
            config.ConvertPrimitives = attributes.Any(a => a is ImplicitConversionAttribute);
            config.RejectNullReferences = attributes.Any(a => a is RejectNullReferencesAttribute);
            config.RequireAllProperties = attributes.Any(a => a is RequireAllPropertiesAttribute);

            return config;
        }
    }
}
