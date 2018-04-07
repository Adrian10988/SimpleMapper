using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    public interface IMappable<TOut> where TOut: new()
    {
        TOut Map<TIn>(TIn mapTarget);
    }
}
