using SimpleMapper.Attributes;
using SimpleMapper.Factories;
using SimpleMapper.Models;
using SimpleMapper.Utilities;
using System.Linq;

namespace SimpleMapper
{
    public abstract class BaseMappable<TIn, TOut> : IMappable<TIn, TOut> where TOut: new()
    {
        protected ClassMappingConfiguration _config;
        protected readonly IGetProperties _getProps;
        protected readonly IClassLevelRuleFactory _classLevelRuleFactory;
        protected IClassMapper _mapper;
        protected readonly IClassMappingConfigurationFactory _classMappingConfigFact;

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

       
        public TOut Map(TIn mapTarget)
        {
            return _mapper.Map<TIn, TOut>(_config, mapTarget);
        }

        protected internal ClassMappingConfiguration GetClassMappingConfiguration()
        {
            return _classMappingConfigFact.Create(GetType());
        }
    }
}
