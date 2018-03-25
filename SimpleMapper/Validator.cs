using SimpleMapper.Factories;
using SimpleMapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper
{
    public static class Validator
    {
        private static List<Exception> _aggregatedExceptions;
        private static IClassMappingConfigurationFactory _configFactory;
        private static IGetProperties _getProps;
        private static IClassLevelRuleFactory _classLevelRuleFactory;

        static Validator()
        {
            _configFactory = new ClassMappingConfigurationFactory();
            _getProps = new GetPublicAndPrivateProperties();
            _classLevelRuleFactory = new ClassLevelRuleFactory(_getProps);
        }
        public static void ValidateMappings(List<Assembly> assemblies)
        {
            _aggregatedExceptions = new List<Exception>();

            var types = GetAllMappingTypes(assemblies);
           
        }

        private static List<Type> GetAllMappingTypes(List<Assembly> assemblies)
        {
            var allDtos = new List<Type>();

            foreach (var a in assemblies)
            {
                var types = a.GetTypes().Where(b => b == typeof(BaseMappable<object, object>));

                foreach (var type in types)
                {
                    if (!allDtos.Contains(type))
                        allDtos.Add(type);
                }
            }
            return allDtos;
        }
   
    }
}
