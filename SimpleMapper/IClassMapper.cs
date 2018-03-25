using System;
using SimpleMapper.Models;

namespace SimpleMapper
{
    public interface IClassMapper
    {
        TOut Map<TIn, TOut>(ClassMappingConfiguration classConfig, TIn fromGeneric) where TOut: new ();
    }
}