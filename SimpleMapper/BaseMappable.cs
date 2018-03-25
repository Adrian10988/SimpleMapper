using ShipBob.Mapper.Attributes;
using ShipBob.Mapper.Factories;
using ShipBob.Mapper.Models;
using ShipBob.Mapper.Utilities;
using System.Linq;

namespace SimpleMapper
{
    public abstract class BaseMappable<TIn, TOut> : IMappable<TIn, TOut> where TOut: new()
    {
        private ClassMappingConfiguration _config;
        private IGetProperties _getProps;
        private IClassLevelRuleFactory _classLevelRuleFactory;
        private IClassMapper _mapper;
        private IClassMappingConfigurationFactory _classMappingConfigFact;

        public BaseMappable()
        {
            _classMappingConfigFact = new ClassMappingConfigurationFactory();
            _config = GetClassMappingConfiguration();
            _getProps = new GetPublicAndPrivateProperties();
            _classLevelRuleFactory = new ClassLevelRuleFactory(_getProps);
            _mapper = new ClassMapper(
                _classLevelRuleFactory.CreateRules(_config),
                _getProps,
                new CopyStrategyFactory());
        }

       
        public TOut Map(TIn mapTarget)
        {
            return _mapper.Map<TIn, TOut>(_config, mapTarget);
        }

        private ClassMappingConfiguration GetClassMappingConfiguration()
        {
            return _classMappingConfigFact.Create(GetType());
        }
    }
}
