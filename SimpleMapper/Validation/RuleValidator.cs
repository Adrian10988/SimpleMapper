using SimpleMapper.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimpleMapper.Validation
{
    internal class RuleValidator
    {
        private readonly IClassMappingConfigurationFactory _configFactory;
        private readonly IClassLevelRuleFactory _classLevelRuleFactory;

        internal RuleValidator(IClassMappingConfigurationFactory configFactory,
            IClassLevelRuleFactory classLevelRuleFactory)
        {
            _configFactory = configFactory;
            _classLevelRuleFactory = classLevelRuleFactory;
        }

        internal void ValidateType(Type targetType)
        {
            var config = _configFactory.Create(targetType);
            var rules = _classLevelRuleFactory.CreateRules(config);
            var toType = targetType.BaseType.GetGenericArguments()[1].UnderlyingSystemType;

            rules.ToList().ForEach(a => a.Run(config, targetType, toType));
        }
    }
}
