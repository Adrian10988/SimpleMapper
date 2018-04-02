using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    public interface IMappable<TIn, TOut> where TOut: new()
    {
        TOut Map(TIn mapTarget);
    }
}
