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
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp, PropertyMappingConfiguration toPropConfig)
        {
            if (!ShouldCopy(tFrom, tTo, toProp, fromProp, toPropConfig))
                return;

            if (_rules != null && _rules.Any())
                _rules.ToList().ForEach(a => a.Run(toPropConfig, tFrom, tTo, toProp, fromProp));

            var tFromType = tFrom.GetType();
            var tToType = tTo.GetType();
          

            var fromVal = fromProp.GetValue(tFrom);
            //no casting needed
            if(toProp.PropertyType == fromProp.PropertyType)
            {
                toProp.SetValue(tTo, fromVal);
                return;
            }

            //if destination is string then job is easy
            if(toProp.PropertyType == typeof(string))
            {
                toProp.SetValue(tTo, fromVal.ToString());
                return;
            }

            //destination is some number type
            if(!new List<Type>()
            {
                typeof(DateTime),
                typeof(TimeSpan)
            }.Contains(toProp.PropertyType))
            {
                ConvertToNumber(tFrom, tTo, toProp, fromProp);
            }
            else
            {
                //destination type is date or timespan value
                ConvertToDateOrTimeValue(tFrom, tTo, toProp, fromProp);
            }
            
        }


        private void ConvertToDateOrTimeValue<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp)
        {
            if (fromProp.PropertyType != typeof(string))
                throw new ArgumentException($"SimpleMapper can only implicityl convert string types to date or timespan types. You attempted to convert type : {fromProp.PropertyType} to type : {toProp.PropertyType}"
                    + $"From class: {tFrom.GetType()}.{fromProp.Name} to Class: {tTo.GetType()}.{toProp.Name}");

            var fVal = fromProp.GetValue(tFrom);

            if(toProp.PropertyType == typeof(DateTime))
            {
                toProp.SetValue(tTo, DateTime.Parse(fVal.ToString()));
            }
            else
            {
                toProp.SetValue(tTo, TimeSpan.Parse(fVal.ToString()));
            }
        }
        private void ConvertToNumber<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp)
        {
            var fVal = fromProp.GetValue(tFrom);
            var toType = toProp.PropertyType;
            if(fromProp.PropertyType == typeof(string))
            {
                if(toType == typeof(int))
                {
                    toProp.SetValue(tTo, int.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(long))
                {
                    toProp.SetValue(tTo, long.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(double))
                {
                    toProp.SetValue(tTo, double.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(decimal))
                {
                    toProp.SetValue(tTo, decimal.Parse(fVal.ToString()));
                    return;
                }

                if(toType == typeof(bool))
                {
                    toProp.SetValue(tTo, bool.Parse(fVal.ToString()));
                    return;
                }
            }
            else
            {
                //conversion is number to number
                toProp.SetValue(tTo, Convert.ChangeType(fVal, toType));
            }
        }

        
    }
}
