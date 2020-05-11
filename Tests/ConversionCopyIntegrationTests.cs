using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Models.ConvertCopy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;
using SimpleMapper;

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
            var result = Mapper.Copy<BarParse, FooParse>(barParse);

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

            var data = Mapper.Copy<Bar, Foo>(bar);

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

            var data = Mapper.Copy<Bar, FooMapFrom>(bar);

            Assert.AreEqual(bar.FirstName, data.LastName);
            Assert.AreEqual(data.Age, "10");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConversionCopy_RejectNullReferenceClassLevel()
        {
            var data = Mapper.Copy<Bar, FooRejectNullReferences>(null);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConversionCopy_RejectNullReferencePropertyLevel()
        {
            var bar = new Bar()
            {
                FirstName = null
            };

            var data = Mapper.Copy<Bar, FooRejectNullReferences>(bar);
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

            var data = Mapper.Copy<Bar, FooRequireAllProperties>(bar);
        }

        [TestMethod]
        public void ConversionCopy_EnumToInt()
        {
            var bar = new BarEnumToInt()
            {
                Enum = Models.TestEnum.One
            };

            var data = Mapper.Copy<BarEnumToInt, FooEnumToInt>(bar);

            Assert.AreEqual(data.Enum, (int)bar.Enum);
        }

        [TestMethod]
        public void ConversionCopy_IntToEnum()
        {
            var bar = new BarIntToEnum()
            {
                Enum = 1
            };

            var data = Mapper.Copy<BarIntToEnum, FooIntToEnum>(bar);

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

            var data = Mapper.Copy<BarEnumToBool, FooEnumToBool>(bar);
        }
        public void ConversionCopy_NullableToString_WhenNullableHasValue()
        {
            var bar = new NullableBar()
            {
                Age = 10,
                FirstName = "John"
            };

            var data = Mapper.Copy<NullableBar, NullableFoo>(bar);

            Assert.AreEqual(bar.FirstName, data.FirstName);
            Assert.AreEqual(data.Age, "10");
        }

        [TestMethod]
        public void ConversionCopy_NullableToString_WhenNullableHasNoValue()
        {
            var bar = new NullableBar()
            {
                Age = null,
                FirstName = "John"
            };

            var data = Mapper.Copy<NullableBar, NullableFoo>(bar);

            Assert.AreEqual(bar.FirstName, data.FirstName);
            Assert.AreEqual(data.Age, bar.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConversionCopy_Int_To_DateTime()
        {
            var bar = new BarIntToDateTime()
            {
                Property = 1
            };

            var data = Mapper.Copy<BarIntToDateTime, FooIntToDateTime>(bar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ConversionCopy_BoolToEnum()
        {
            var bar = new BarBoolToEnum()
            {
                Enum = false
            };

            var data = Mapper.Copy<BarBoolToEnum, FooBoolToEnum>(bar);
        }
        public void ConversionCopy_NullableDate_ToNonNullableDate()
        {
            var bar = new NullableBar()
            {
                Age = 11,
                BirthDate = null,
                FirstName = "John"
            };

            var data = Mapper.Copy<NullableBar, NonNullableFoo>(bar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ConversionCopy_NullableNumber_ToNonNullableNumber()
        {
            var bar = new NullableBar()
            {
                Age = null,
                BirthDate = DateTime.Now,
                FirstName = "John"
            };

            var data = Mapper.Copy<NullableBar, NonNullableFoo>(bar);
        }
    }
}
