using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    public interface IMappable<TFrom, TOut> where TFrom: new() where TOut: new()
    {
        TOut Map(TFrom mapTarget);
    }
}
