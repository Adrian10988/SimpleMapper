using SimpleMapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    internal interface IClassTwoWayMapper : IClassMapper
    {
        TIn Map<TIn, TOut>(ClassMappingConfiguration classConfig, TOut fromGeneric) where TIn : new();
    }
}
