using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShipBob.Mapper.Test.Models;
using SimpleMapper.Test.Models;
using SimpleMapper.Test.Models.ConvertCopy;
using SimpleMapper.Test.Models.DefaultCopy;

namespace SimpleMapper.Test
{
    [TestClass]
    public class CopyTests
    {

        [TestMethod]
        public void DefaultCopy_HappyPath()
        {
            var bar = new Bar()
            {
                A = "A",
                B = 1,
                C = 2.15,
                D = 3.15M,
                E = 99999,
                ShouldBypass = -100,
                DoesNotExistInFoo = "123123123123"
            };

            var foo = bar.Map(bar);

            Assert.AreEqual(bar.A, foo.A);
            Assert.AreEqual(bar.B, foo.B);
            Assert.AreEqual(bar.C, foo.C);
            Assert.AreEqual(bar.D, foo.D);
            Assert.AreEqual(bar.E, foo.E);
            Assert.AreNotEqual(bar.ShouldBypass, foo.ShouldBypass);
        }

        [TestMethod]
        public void ConvertCopy_HappyPath()
        {
            var foo = new FooConvertCopy()
            {
                StringToBool = "true",
                StringToDecimal = "12.52",
                StringToDouble = "12.52",
                StringToInt = "55",
                StringToLong = "10000"
            };

            var bar = foo.Map(foo);

            Assert.IsTrue(bar.StringToBool == true);
            Assert.IsTrue(bar.StringToDecimal == 12.52M);
            Assert.IsTrue(bar.StringToDouble == 12.52);
            Assert.IsTrue(bar.StringToInt == 55);
            Assert.IsTrue(bar.StringToLong == 10000);

        }
        [TestMethod]
        public void DefaultCopy_ReturnNullReference()
        {
            var mapSlave = new Bar();

            var foo = mapSlave.Map(default(Bar));
            Assert.IsTrue(foo == null);
        }

        [TestMethod]
        public void ShouldSkip_ReferenceObjects()
        {
            var foo = new FooReference()
            {
                ConvertTest = "I passed!",
                ReferenceObject = new FooMissingMember()
                {
                    A = "Should not have copied"
                }
            };

            var bar = foo.Map(foo);

            Assert.AreEqual(foo.ConvertTest, bar.ConvertTest);
            Assert.IsNull(bar.ReferenceObject);
        }

        [TestMethod]
        public void MapToAttribute_HappyPath()
        {
            var foo = new FooExplicitModel()
            {
                A1 = "Test",
                B1 = 1,
                C1 = 2.12,
                D1 = 2.33M,
                E1 = true,
                F1 = 999
            };

            var bar = foo.Map(foo);

            Assert.AreEqual(foo.A1, bar.A2);
            Assert.AreEqual(foo.B1, bar.B2);
            Assert.AreEqual(foo.C1, bar.C2);
            Assert.AreEqual(foo.D1, bar.D2);
            Assert.AreEqual(foo.E1, bar.E2);
            Assert.AreEqual(foo.F1, bar.F2);
            
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ShouldError_FormatException()
        {
            var foo = new FooConvertCopy()
            {
                StringToBool = "123",
                StringToDecimal = "12.52",
                StringToDouble = "12.52",
                StringToInt = "55",
                StringToLong = "10000"
            };

            var bar = foo.Map(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void ShouldError_AllPropertiesMustMatch()
        {
            var bar = new BarMissingMember()
            {
                A = "123",
                B = "123"
            };

            var foo = bar.Map(bar);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldError_RejectNullReferences()
        {
            var mapSlave = new BarRejectNullReference();
            mapSlave.Map(default(BarRejectNullReference));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ShouldError_InvalidCastException()
        {
            //This method differs from `ShouldError_FormatException` in that this occurs only when the `DefaultCopyStrategy` is used
            //while the `FormatException` is raised if the `ConvertCopyStrategy` is used

            var foo = new FooInvalidCastException()
            {
                InvalidCast = "123"
            };

            var bar = foo.Map(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldError_RejectNullReferences_PropertyLevel()
        {
            var foo = new FooNullProperty();
            var bar = foo.Map(foo);
        }
    }
}
