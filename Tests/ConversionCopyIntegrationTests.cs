using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Models.ConvertCopy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests
{
    [TestClass]
    public class ConversionCopyIntegrationTests
    {
        [TestMethod]
        public void ConversionCopy_ParseHappyPath()
        {
            var barParse = new BarParse()
            {
                Age = "29",
                GPA = "3.0",
                SecondsAlive = "1234567",
                TimeSpanAlive = DateTime.Now - DateTime.Parse("10/09/1988"),
                Birthdate = DateTime.Parse("10/09/1988"),
                FirstName = "Adrian",
                IsHappy = true,
                MoneyToTheWallet = "1800.23"
            };

            var mapSlave = new FooParse();
            var result = mapSlave.Map(barParse);

            Assert.AreEqual(result.Age, 29);
            Assert.AreEqual(result.GPA, 3);
            Assert.AreEqual(result.MoneyToTheWallet, 1800.23M);
            Assert.AreEqual(result.SecondsAlive, 1234567);
        }

        [TestMethod]
        public void ConversionCopy_ToStringHappyPath()
        {
            var bar = new Bar()
            {
                Age = 10
            };

            var mapSlave = new Foo();

            var data = mapSlave.Map(bar);

            Assert.IsTrue(data.Age == "10");
        }

        [TestMethod]
        public void ConversionCopy_MapFrom()
        {
            var bar = new Bar()
            {
                FirstName = "LaLa",
                Age = 10
            };

            var mapSlave = new FooMapFrom();

            var data = mapSlave.Map(bar);

            Assert.AreEqual(bar.FirstName, data.LastName);
            Assert.AreEqual(data.Age, "10");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConversionCopy_RejectNullReferenceClassLevel()
        {
            var mapSlave = new FooRejectNullReferences();
            var data = mapSlave.Map(null);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConversionCopy_RejectNullReferencePropertyLevel()
        {
            var bar = new Bar()
            {
                FirstName = null
            };

            var mapSlave = new FooRejectNullReferences();
            var data = mapSlave.Map(bar);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void ConversionCopy_AllPropertiesRequired()
        {
            var bar = new Bar()
            {
                FirstName = "Adrian",
                Age = 29,
                Birthdate = new DateTime(1988, 10, 9),
                GPA = 3.0,
                IsHappy = true,
                MoneyToTheWallet = 1789.23M,
                SecondsAlive = 102928392839383928,
                TimeSpanAlive = DateTime.Now - new DateTime(1988, 10, 9)
            };

            var mapSlave = new FooRequireAllProperties();
            var data = mapSlave.Map(bar);
        }

        [TestMethod]
        public void ConversionCopy_EnumToInt()
        {
            var bar = new BarEnumToInt()
            {
                Enum = Models.TestEnum.One
            };

            var mapSlave = new FooEnumToInt();

            var data = mapSlave.Map(bar);

            Assert.AreEqual(data.Enum, (int)bar.Enum);
        }

        [TestMethod]
        public void ConversionCopy_IntToEnum()
        {
            var bar = new BarIntToEnum()
            {
                Enum = 1
            };

            var mapSlave = new FooIntToEnum();

            var data = mapSlave.Map(bar);

            Assert.AreEqual(data.Enum, (TestEnum)bar.Enum);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ConversionCopy_EnumToBool()
        {
            var bar = new BarEnumToBool()
            {
                Enum = TestEnum.One
            };

            var mapSlave = new FooEnumToBool();

            var data = mapSlave.Map(bar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ConversionCopy_BoolToEnum()
        {
            var bar = new BarBoolToEnum()
            {
                Enum = false
            };

            var mapSlave = new FooBoolToEnum();

            var data = mapSlave.Map(bar);
        }
    }
}
