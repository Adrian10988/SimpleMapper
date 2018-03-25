using SimpleMapper.Factories;
using SimpleMapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper.Validation
{
    public static class Validator
    {
        private readonly static List<Exception> _aggregatedExceptions;
        private readonly static IClassMappingConfigurationFactory _configFactory;
        private readonly static IGetProperties _getProps;
        private readonly static IClassLevelRuleFactory _classLevelRuleFactory;

        static Validator()
        {
            _configFactory = new ClassMappingConfigurationFactory();
            _getProps = new GetPublicAndPrivateProperties();
            _classLevelRuleFactory = new ClassLevelRuleFactory(_getProps);
            _aggregatedExceptions = new List<Exception>();
        }
        public static void ValidateMappings(List<Assembly> assemblies)
        {
           

            var types = GetAllMappingTypes(assemblies);
            var validator = new RuleValidator(new ClassMappingConfigurationFactory(),
                new ClassLevelRuleFactory(
                    new GetPublicAndPrivateProperties()));

            foreach(var type in types)
            {
                try
                {
                    validator.ValidateType(type);
                }
                catch(Exception e)
                {
                    _aggregatedExceptions.Add(e);
                }
                
            }

            if (_aggregatedExceptions.Any())
            {
                throw new AggregateException(_aggregatedExceptions);
            }
        }

        private static List<Type> GetAllMappingTypes(List<Assembly> assemblies)
        {
            var allDtos = new List<Type>();

            foreach (var a in assemblies)
            {
                var types = GetAllTypesThatImplementBaseMappable(a);

                foreach (var type in types)
                {
                    if (!allDtos.Contains(type))
                        allDtos.Add(type);
                }
            }
            return allDtos;
        }

        private static List<Type> GetAllTypesThatImplementBaseMappable(Assembly assembly)
        {
            var types = from x in assembly.GetTypes()
                                        let y = x.BaseType
                                        where !x.IsAbstract && !x.IsInterface &&
                                        y != null && y.IsGenericType &&
                                        y.GetGenericTypeDefinition() == typeof(BaseMappable<,>)
                                        select x;

            return types.ToList();
        }
   
    }
}
