using ShipBob.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleMapper.Rules
{
    /// <summary>
    /// Rules are for validation only and should either do nothing or throw an exception
    /// </summary>
    public interface IPropertyLevelRule
    {
        void Run<TOut>(PropertyMappingConfiguration config, object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to);
    }
}
