using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMapper.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test
{
    [TestClass]
    public class ValidatorTests
    {
        //Figure out a way to test this validator. Impossible to test since other tests require invalid mapping configurations
        [TestMethod]
        [Ignore]
        public void Validate_HappyPath()
        {
            Validator.ValidateMappings(new List<System.Reflection.Assembly>()
            {
                GetType().Assembly
            });
        }
    }
}
