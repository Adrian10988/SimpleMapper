using SimpleMapper.Attributes;
using SimpleMapper.Factories;
using SimpleMapper.Models;
using SimpleMapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMapper
{
    public static class Mapper
    {
        private static readonly IGetProperties _getProps;
        private static readonly IClassLevelRuleFactory _classLevelRuleFactory;
        private static readonly IClassMappingConfigurationFactory _classMappingConfigFact;

        private static bool _registrationOverridden = false;
        //TODO
        //potentially can offer a configuration hook that allows configuration of the static instance -A

        static Mapper()
        {
            _classMappingConfigFact = new ClassMappingConfigurationFactory();
            _getProps = new GetPublicAndPrivateProperties();
            _classLevelRuleFactory = new ClassLevelRuleFactory(_getProps);
        }

        public static TDestination Copy<TSource, TDestination>(TSource source) where TSource : new() where TDestination: new()
        {
            ValidateSuppliedMappingTypes<TSource, TDestination>();

            var config = CreateClassMappingConfiguration<TSource, TDestination>();
            var mapper = CreateClassMapper(source, config);
            return mapper.Map<TSource, TDestination>(config, source);
        }
        private static ClassMappingConfiguration CreateClassMappingConfiguration<TSource, TDestination>()
        {
            return _classMappingConfigFact.Create(typeof(TSource), typeof(TDestination));
        }
        private static IClassMapper CreateClassMapper<TSource>(TSource source, ClassMappingConfiguration config)
        {
            return new ClassMapper(
                _classLevelRuleFactory.CreateRules(config),
                _getProps,
                new CopyStrategyFactory(),
                new PropertyMappingStrategyFactory());
        }
        private static void ValidateSuppliedMappingTypes<TSource, TDestination>()
        {
            //the source type must have a `MapTarget` attribute pointing to the destination object
            var sourceAttrs = typeof(TSource).GetCustomAttributes(true).ToList();
            var destAttrs = typeof(TDestination).GetCustomAttributes(true).ToList();

            if (!sourceAttrs.Any(a => a is MapDestinationAttribute))
                throw new ArgumentException($"{typeof(TSource)} is not mappable. Please use a `MapFromAttribute` on the source class in order to mark it as a map supported class.");

            var destinationTargetTypes = ((MapDestinationAttribute)sourceAttrs.First(a => a is MapDestinationAttribute)).Types;

            if (!destinationTargetTypes.Contains(typeof(TDestination)))
                throw new ArgumentException($"{typeof(TDestination)} is not registered to {typeof(TSource)} and cannot be mapped. Please ensure {typeof(TSource)}'s `MapTargetAttribute` references {typeof(TDestination)}");
        }
    }
}
