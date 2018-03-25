using System.Collections.Generic;
using SimpleMapper.Models;
using SimpleMapper.Rules;

namespace SimpleMapper.Factories
{
    public interface IClassLevelRuleFactory
    {
        IEnumerable<IClassLevelRule> CreateRules(ClassMappingConfiguration config);
    }
}