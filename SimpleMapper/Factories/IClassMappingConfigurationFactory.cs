using System;
using ShipBob.Mapper.Models;

namespace SimpleMapper.Factories
{
    public interface IClassMappingConfigurationFactory
    {
        ClassMappingConfiguration Create(Type t);
    }
}