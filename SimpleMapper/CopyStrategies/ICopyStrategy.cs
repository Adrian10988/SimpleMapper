using ShipBob.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleMapper.CopyStrategies
{
    public interface ICopyStrategy
    {
        void Copy<TOut>(object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to, PropertyMappingConfiguration config);
    }
}
