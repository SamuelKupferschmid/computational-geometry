using Geometry2D;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry2DTests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void MhDistTest() => Assert.AreEqual(8,new Vector(3,-5).MhnDist);

        [TestMethod]
        public void AddOperatorUsesOffset() => Assert.AreEqual(new Vector(6, 3), new Vector(2, 4) + new Vector(4, -1));

        [TestMethod]
        public void SubtractOperatorUsesOffset() => Assert.AreEqual(new Vector(6, 3), new Vector(9, 8) - new Vector(3, 5));

        [TestMethod]
        public void MultipleIsTrue() => Assert.IsTrue(new Vector(4, 6).IsMultiple(new Vector(2, 3)));

        [TestMethod]
        public void MultipleNullIsTrue() => Assert.IsTrue(new Vector(0, 0).IsMultiple(new Vector(0, 0)));
    }
}