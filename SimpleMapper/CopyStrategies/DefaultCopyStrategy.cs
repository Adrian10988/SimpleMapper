using ShipBob.Mapper.Models;
using ShipBob.Mapper.Rules;
using ShipBob.Mapper.Utilities;
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
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to, PropertyMappingConfiguration config)
        {
            if (!ShouldCopy(tFrom, tTo, from, to, config))
                return;

            if (_rules != null && _rules.Any())
                _rules.ToList().ForEach(a => a.Run(config, tFrom, tTo, from, to));

            if (from.PropertyType != to.PropertyType)
                throw new InvalidCastException($"{tFrom.GetType()}.{from.Name} is not the same type as {tTo.GetType()}.{to.Name}");

            var fromVal = from.GetValue(tFrom);
            to.SetValue(tTo, fromVal);
        }
    }
}
