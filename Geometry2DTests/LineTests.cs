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

        [TestMethod]
        public void IntersectionSimple()
        {
            var l1 = new Line(new Vector(1,0),new Vector(0,1));
            var l2 = new Line(new Vector(0,1),new Vector(1,0));

            var v = default(Vector);
            Assert.IsTrue(l1.Intersects(l1, out v));

            Assert.AreEqual(new Vector(1,1),v);
        }

        [TestMethod]
        public void IsOnLineSimple()
            => Assert.IsTrue(new Line(Vector.Null, new Vector(4, 2)).IsOnLine(new Vector(6, 3)));
    }
}