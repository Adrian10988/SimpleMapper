using System;
using ShipBob.Mapper.Models;

namespace SimpleMapper
{
    public interface IClassMapper
    {
        TOut Map<TIn, TOut>(ClassMappingConfiguration classConfig, TIn fromGeneric) where TOut: new ();
    }
}