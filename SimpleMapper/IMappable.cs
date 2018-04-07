using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    public interface IMappable<TFrom> where TFrom: new()
    {
        TOut Map<TOut>(TFrom mapTarget) where TOut : new();
    }
}
