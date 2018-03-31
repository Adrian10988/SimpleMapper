﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    /// <summary>
    /// Allows one way mapping from source to target
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IMappable<TIn, TOut> where TOut: new()
    {
        TOut Map(TIn mapTarget);
    }
}
