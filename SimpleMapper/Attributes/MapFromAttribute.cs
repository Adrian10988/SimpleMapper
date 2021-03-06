﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapFromAttribute : Attribute
    {
        public string PropertyName { get; set; }
    }
}
