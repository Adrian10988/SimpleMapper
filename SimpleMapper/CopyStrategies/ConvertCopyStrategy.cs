using SimpleMapper.Models;
using SimpleMapper.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper.CopyStrategies
{
    public class ConvertCopyStrategy : BaseCopyStrategy, ICopyStrategy
    {
        private readonly IEnumerable<IPropertyLevelRule> _rules;
        
        public ConvertCopyStrategy(IEnumerable<IPropertyLevelRule> rules)
        {
            _rules = rules;
        }
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to, PropertyMappingConfiguration config)
        {
            if (!ShouldCopy(tFrom, tTo, from, to, config))
                return;

            if (_rules != null && _rules.Any())
                _rules.ToList().ForEach(a => a.Run(config, tFrom, tTo, from, to));

            var tFromType = tFrom.GetType();
            var tToType = tTo.GetType();
          

            var fromVal = from.GetValue(tFrom);
            //no casting needed
            if(from.PropertyType == to.PropertyType)
            {
                to.SetValue(tTo, fromVal);
                return;
            }

            //if destination is string then job is easy
            if(to.PropertyType == typeof(string))
            {
                to.SetValue(tTo, fromVal.ToString());
                return;
            }

            //destination is some number type
            ConvertToNumber(tFrom, tTo, from, to);
        }

       

        private void ConvertToNumber<TOut>(object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to)
        {
            var fVal = from.GetValue(tFrom);
            var toType = to.PropertyType;
            if(from.PropertyType == typeof(string))
            {
                if(toType == typeof(int))
                {
                    to.SetValue(tTo, int.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(long))
                {
                    to.SetValue(tTo, long.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(double))
                {
                    to.SetValue(tTo, double.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(decimal))
                {
                    to.SetValue(tTo, decimal.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(bool))
                {
                    to.SetValue(tTo, bool.Parse(fVal.ToString()));
                    return;
                }
            }
            else
            {
                //conversion is number to number
                to.SetValue(tTo, Convert.ChangeType(fVal, toType));
            }
        }

        
    }
}
