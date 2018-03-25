using ShipBob.Mapper.CopyStrategies;
using ShipBob.Mapper.Models;

namespace SimpleMapper.Factories
{
    public interface ICopyStrategyFactory
    {
        ICopyStrategy GetStrategy(ClassMappingConfiguration classConfig, PropertyMappingConfiguration propConfig);
    }
}