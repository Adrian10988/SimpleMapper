using SimpleMapper.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleMapper.CopyStrategies
{
    public abstract class BaseCopyStrategy
    {
        protected bool ShouldCopy<TOut>(object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp, PropertyMappingConfiguration toPropConfig)
        {
            if (!Constants.TypeWhiteList.Contains(toProp.PropertyType) || !Constants.TypeWhiteList.Contains(fromProp.PropertyType))
                return false;
            else
                return true;
        }
    }
}
