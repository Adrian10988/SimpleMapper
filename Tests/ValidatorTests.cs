using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMapper.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ValidatorTests
    {
        //Figure out a way to test this validator. Impossible to test since other tests require invalid mapping configurations. Meaning some tests are
        //meant to fail in this solution and if we run a test that grabs all mappings, even the ones meant to fail, then this test will always fail. 
        //we need this test to pass during the happy path

        //possible solutions, make a new project for this, mark test pocos with an attribute to denote they are meant to fail and only get the ones without the attribute,
        //etc
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
