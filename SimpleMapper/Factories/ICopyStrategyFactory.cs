using SimpleMapper.CopyStrategies;
using SimpleMapper.Models;

namespace SimpleMapper.Factories
{
    public interface ICopyStrategyFactory
    {
        ICopyStrategy GetStrategy(ClassMappingConfiguration classConfig, PropertyMappingConfiguration propConfig);
    }
}