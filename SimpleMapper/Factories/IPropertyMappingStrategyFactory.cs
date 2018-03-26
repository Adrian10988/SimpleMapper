using System.Reflection;
using SimpleMapper.PropertyMappingStrategies;

namespace SimpleMapper.Factories
{
    public interface IPropertyMappingStrategyFactory
    {
        IPropertyMappingStrategy Create(PropertyInfo matchKey);
    }
}