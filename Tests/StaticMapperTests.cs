using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class StaticMapperTests
    {

        #region test classes
        [MapTarget(typeof(ValidDestination))]
        private class ValidSource
        {
            public string Name { get; set; } = "Garfield";
        }

        private class ValidDestination
        {
            public string Name { get; set; }
        }

        [MapTarget(typeof(ReverseMappableDestination))]
        private class ReverseMappableSource
        {
            public string Name { get; set; } = "Garfield";
        }

        [MapTarget(typeof(ReverseMappableSource))]
        private class ReverseMappableDestination
        {
            public string Name { get; set; }
        }

        [MapTarget(typeof(MultiDestinationOne), typeof(MultiDestinationTwo))]
        private class MultiDestinedSource
        {
            public string Name { get; set; } = "Scratchy";
        }


        private class MultiDestinationOne
        {
            public string Name { get; set; }
        }
        private class MultiDestinationTwo
        {
            public string Name { get; set; }
        }

        private class InvalidDestination
        {

        }

        private class InvalidSource
        {

        }

        #endregion


        [TestMethod]
        public void HappyPath()
        {
            var dest = SimpleMapper.Mapper.Build<ValidSource, ValidDestination>(new ValidSource());
            Assert.IsTrue(dest is ValidDestination);
        }

        [TestMethod]
        public void HappyPath_AllowReverseMappingWhenConfiguredCorrectly()
        {
            var dest = SimpleMapper.Mapper.Build<ReverseMappableSource, ReverseMappableDestination>(new ReverseMappableSource());
            var source = SimpleMapper.Mapper.Build<ReverseMappableDestination, ReverseMappableSource>(dest);

            Assert.IsTrue(dest is ReverseMappableDestination);
            Assert.IsTrue(source is ReverseMappableSource);
            Assert.AreEqual(dest.Name, source.Name);
        }

        [TestMethod]
        public void HappyPath_SourceMapsToMultipleTargets()
        {

            var src = new MultiDestinedSource();
            var destOne = SimpleMapper.Mapper.Build<MultiDestinedSource, MultiDestinationOne>(src);
            var destTwo = SimpleMapper.Mapper.Build<MultiDestinedSource, MultiDestinationTwo>(src);

            Assert.IsTrue(destOne is MultiDestinationOne);
            Assert.IsTrue(destTwo is MultiDestinationTwo);

            Assert.AreEqual(src.Name, destOne.Name);
            Assert.AreEqual(src.Name, destTwo.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Exception_SourceDoesNotHaveMapTargetAttribute()
        {
            var dest = SimpleMapper.Mapper.Build<InvalidSource, ValidDestination>(new InvalidSource());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Exception_TargetIsNotRegisteredOnSource()
        {
            var dest = SimpleMapper.Mapper.Build<ValidSource, InvalidDestination>(new ValidSource());
        }
    }
}
