using System;
using System.Collections.Generic;
using System.Text;
using SimpleMapper.Factories;
using SimpleMapper.Models;
using SimpleMapper.Rules;
using SimpleMapper.Utilities;

namespace SimpleMapper
{
    internal class ClassTwoWayMapper : ClassMapper, IClassTwoWayMapper
    {
        public ClassTwoWayMapper(IEnumerable<IClassLevelRule> rules,
            IGetProperties getProps, ICopyStrategyFactory copyStrategyFactory,
            IPropertyMappingStrategyFactory propertyMappingStrategyFactory) 
            : base(rules, getProps, copyStrategyFactory, propertyMappingStrategyFactory)
        {

        }

        public TIn Map<TIn, TOut>(ClassMappingConfiguration classConfig, TOut fromGeneric) where TIn : new()
        {
            throw new NotImplementedException();
        }
    }
}
