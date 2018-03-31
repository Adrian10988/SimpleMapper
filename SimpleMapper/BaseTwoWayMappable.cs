using SimpleMapper.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    public abstract class BaseTwoWayMappable<TIn, TOut> : BaseMappable<TIn, TOut>, ITwoWayMappable<TIn, TOut> 
        where TOut : new() where TIn : new ()
    {
        private new IClassTwoWayMapper _mapper;

        public BaseTwoWayMappable() : base()
        {
            _mapper = new ClassTwoWayMapper(
                _classLevelRuleFactory.CreateRules(_config),
                _getProps,
                new CopyStrategyFactory(),
                new PropertyMappingStrategyFactory());
        }

        public TIn Map(TOut mapTarget)
        {
            return _mapper.Map<TIn, TOut>(_config, mapTarget);
        }
    }
}
