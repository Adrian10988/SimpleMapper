using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ShipBob.Mapper.Models;

namespace SimpleMapper.CopyStrategies
{
    public class BypassCopyStrategy : ICopyStrategy
    {
       
        public void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to, PropertyMappingConfiguration config)
        {
            //do nothing
        }
    }
}
