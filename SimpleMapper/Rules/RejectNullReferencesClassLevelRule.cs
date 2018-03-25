﻿using System;
using System.Collections.Generic;
using System.Text;
using ShipBob.Mapper.Models;

namespace SimpleMapper.Rules
{
    public class RejectNullReferencesClassLevelRule : IClassLevelRule
    {
        public void Run(ClassMappingConfiguration config, Type from, Type to, object inObject = null)
        {
            if (config.RejectNullReferences && (inObject is null))
            {
                throw new NullReferenceException(@"A null reference was passed into the mapper. If this is not desired behavior please remove 
any class level attributes entitled [RejectNullReferences]");
            }
        }
    }
}