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
        //TODO -- figure out how to test this better. Some classes will throw exceptions while others should not
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
