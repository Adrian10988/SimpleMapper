using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    /// <summary>
    /// Allows implementation of mapping to and from two dto's from a single class
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface ITwoWayMappable<TIn, TOut> : IMappable<TIn, TOut> where TOut : new()
    {
        TIn Map(TOut mapTarget);
    }
}
