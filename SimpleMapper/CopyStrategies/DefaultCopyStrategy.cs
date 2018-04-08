using SimpleMapper.Models;
using SimpleMapper.Rules;
using SimpleMapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper.CopyStrategies
{
    public class DefaultCopyStrategy : BaseCopyStrategy, ICopyStrategy
    {
        private readonly IEnumerable<IPropertyLevelRule> _rules;
        public DefaultCopyStrategy(IEnumerable<IPropertyLevelRule> rules)
        {
            _rules = rules;
        }
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp, PropertyMappingConfiguration toPropConfig)
        {
            if (!ShouldCopy(tFrom, tTo, toProp, fromProp, toPropConfig))
                return;

            if (_rules != null && _rules.Any())
                _rules.ToList().ForEach(a => a.Run(toPropConfig, tFrom, tTo, toProp, fromProp));

            if (toProp.PropertyType != fromProp.PropertyType)
                throw new InvalidCastException($"{tFrom.GetType()}.{toProp.Name} is not the same type as {tTo.GetType()}.{fromProp.Name}");

            var fromVal = fromProp.GetValue(tFrom);
            toProp.SetValue(tTo, fromVal);
        }
    }
}
