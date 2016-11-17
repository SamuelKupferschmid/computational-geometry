using Geometry2D;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry2DTests
{
    [TestClass()]
    public class PointTests
    {
        [TestMethod()]
        public void MhDistTest() => Assert.AreEqual(8,new Point(3,-5).MhDist);
    }
}