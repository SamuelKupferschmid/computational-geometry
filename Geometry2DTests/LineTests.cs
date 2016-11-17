using Geometry2D;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry2DTests
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void IsParallel() =>
                Assert.IsTrue(new Line(Vector.Null, new Vector(2, 3)).IsParallel(new Line(new Vector(4, -6), new Vector(-1, -1.5))));


        [TestMethod]
        public void IsEqual() => 
            Assert.IsTrue(new Line(new Vector(2, 1), new Vector(4, 2)) == new Line(new Vector(6, 3), new Vector(8, 4)));
    }
}