using System.Collections.Generic;
using ShipBob.Mapper.Models;
using ShipBob.Mapper.Rules;

namespace SimpleMapper.Factories
{
    public interface IClassLevelRuleFactory
    {
        IEnumerable<IClassLevelRule> CreateRules(ClassMappingConfiguration config);
    }
}