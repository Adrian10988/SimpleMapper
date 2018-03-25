using ShipBob.Mapper.Models;
using ShipBob.Mapper.Rules;
using ShipBob.Mapper.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Factories
{
    public class ClassLevelRuleFactory : IClassLevelRuleFactory
    {
        private readonly IGetProperties _getProps;
        public ClassLevelRuleFactory(IGetProperties getProps)
        {
            _getProps = getProps;
        }

        public IEnumerable<IClassLevelRule> CreateRules(ClassMappingConfiguration config)
        {
            var list = new List<IClassLevelRule>();

            if (config.RejectNullReferences)
                list.Add(new RejectNullReferencesClassLevelRule());

            if (config.RequireAllProperties)
                list.Add(new RequireAllPropertiesRule(_getProps));

            return list;
        }
    }
}
