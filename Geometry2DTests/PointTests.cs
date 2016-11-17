using Geometry2D;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry2DTests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void MhDistTest() => Assert.AreEqual(8,new Point(3,-5).MhDist);

        [TestMethod]
        public void AddOperatorUsesOffset() => Assert.AreEqual(new Point(6, 3), new Point(2, 4) + new Point(4, -1));

        [TestMethod]
        public void SubtractOperatorUsesOffset() => Assert.AreEqual(new Point(6, 3), new Point(9, 8) - new Point(3, 5));
    }
}