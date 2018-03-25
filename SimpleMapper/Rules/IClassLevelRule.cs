using ShipBob.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Rules
{
    /// <summary>
    /// Rules are for validation only and should either do nothing or throw an exception
    /// </summary>
    public interface IClassLevelRule
    {
        void Run(ClassMappingConfiguration config, Type from, Type to, object inObject = null);
    }
}
