using ShipBob.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleMapper.CopyStrategies
{
    public abstract class BaseCopyStrategy
    {
        protected bool ShouldCopy<TOut>(object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to, PropertyMappingConfiguration config)
        {
            if (!Constants.TypeWhiteList.Contains(from.PropertyType) || !Constants.TypeWhiteList.Contains(to.PropertyType))
                return false;
            else
                return true;
        }
    }
}
