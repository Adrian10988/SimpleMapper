using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SimpleMapper.Models;

namespace SimpleMapper.CopyStrategies
{
    [Obsolete("As of 2.0.0.0 this attribute does not make sense. To bypass an attribute simple ommit it from the definition class")]
    public class BypassCopyStrategy : ICopyStrategy
    {
       
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp, PropertyMappingConfiguration toPropConfig)
        {
            //do nothing
        }
    }
}
