using SimpleMapper.Attributes;
using SimpleMapper.Factories;
using SimpleMapper.Models;
using SimpleMapper.Rules;
using SimpleMapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper
{
    public class ClassMapper : IClassMapper
    {
        private readonly IEnumerable<IClassLevelRule> _rules;
        private readonly IGetProperties _getProps;
        private readonly ICopyStrategyFactory _copyStrategyFactory;
        private readonly IPropertyMappingStrategyFactory _propertyMappingStrategyFactory;
        public ClassMapper(IEnumerable<IClassLevelRule> rules, IGetProperties getProps, ICopyStrategyFactory copyStrategyFactory,
            IPropertyMappingStrategyFactory propertyMappingStrategyFactory)
        {
            _rules = rules;
            _copyStrategyFactory = copyStrategyFactory;
            _getProps = getProps;
            _propertyMappingStrategyFactory = propertyMappingStrategyFactory;
        }

        public TOut Map<TIn, TOut>(ClassMappingConfiguration classConfig, TIn fromGeneric) where TOut: new()
        {

            var fromType = ((TIn)Activator.CreateInstance(typeof(TIn))).GetType();
            var toObject = (TOut)Activator.CreateInstance(typeof(TOut));
            var toType = toObject.GetType();
            //run pre processing checks
            _rules.ToList().ForEach(a => a.Run(classConfig, fromType, toType, fromGeneric));

            //at this point if TIn was null and the RejectNullReference rule was on, it would have thrown an exception
            //if it didn't, then null inputs are valid... return null
            if (fromGeneric == null)
                return default(TOut);

            var fProps = _getProps.Get(fromType);
            var tProps = _getProps.Get(toType);

            foreach(var prop in fProps)
            {
                var propMapStrategy = _propertyMappingStrategyFactory.Create(prop);
                var matchingToProp = propMapStrategy.Match(tProps, prop);

                if (matchingToProp == null)
                    continue; //default behavior, props that don't line up are ignored. pre processing checks handle instances where props should line up but don't

                var propConfig = GetPropertyMappingConfiguration(prop);
                var strategy = _copyStrategyFactory.GetStrategy(classConfig, propConfig);
                strategy.Copy(fromGeneric, toObject, prop, matchingToProp, propConfig);
            }

            return toObject;
        }

        protected PropertyMappingConfiguration GetPropertyMappingConfiguration(PropertyInfo p)
        {
            var model = new PropertyMappingConfiguration();

            var attrs = p.GetCustomAttributes().ToList();

            model.Bypass = attrs.Any(a => a is BypassAttribute);
            model.RejectNullReferences = attrs.Any(a => a is RejectNullReferencesAttribute);

            return model;
        }
    }
}
