using SimpleMapper.Attributes;
using SimpleMapper.Factories;
using SimpleMapper.Models;
using SimpleMapper.Utilities;
using System.Linq;

namespace SimpleMapper
{
    public abstract class BaseMappable<TFrom, TOut> : IMappable<TFrom, TOut> where TFrom : new() where TOut : new()
    {
        private ClassMappingConfiguration _config;
        private readonly IGetProperties _getProps;
        private readonly IClassLevelRuleFactory _classLevelRuleFactory;
        private readonly IClassMapper _mapper;
        private readonly IClassMappingConfigurationFactory _classMappingConfigFact;

        public BaseMappable()
        {
            _classMappingConfigFact = new ClassMappingConfigurationFactory();
            _config = GetClassMappingConfiguration();
            _getProps = new GetPublicAndPrivateProperties();
            _classLevelRuleFactory = new ClassLevelRuleFactory(_getProps);
            _mapper = new ClassMapper(
                _classLevelRuleFactory.CreateRules(_config),
                _getProps,
                new CopyStrategyFactory(),
                new PropertyMappingStrategyFactory());
        }

       
        public TOut Map(TFrom fromObj)
        {
            return _mapper.Map<TFrom, TOut>(_config, fromObj);
        }

        private ClassMappingConfiguration GetClassMappingConfiguration()
        {
            return _classMappingConfigFact.Create(GetType());
        }

      
    }
}
