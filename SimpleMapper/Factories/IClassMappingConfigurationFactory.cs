using System;
using SimpleMapper.Models;

namespace SimpleMapper.Factories
{
    public interface IClassMappingConfigurationFactory
    {
        ClassMappingConfiguration Create(Type source, Type destination);
        ClassMappingConfiguration Create(Type t);
    }
}