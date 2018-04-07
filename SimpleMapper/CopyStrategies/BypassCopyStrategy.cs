using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SimpleMapper.Models;

namespace SimpleMapper.CopyStrategies
{
    public class BypassCopyStrategy : ICopyStrategy
    {
       
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp, PropertyMappingConfiguration toPropConfig)
        {
            //do nothing
        }
    }
}
