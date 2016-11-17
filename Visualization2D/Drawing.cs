using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometry2D;

namespace Visualization2D
{
    public class Drawing : IEnumerable<IGeometricElement>
    {
        public Drawing()
        {
            ViewPoint = Vector.Null;
            AutoView = true;
        }

        private readonly List<IGeometricElement> _elements = new List<IGeometricElement>();

        private const double MarginFactor = 0.2;
        private const double MarginFallback = 10;

        [Browsable(true)]
        public IEnumerable<IGeometricElement> Elements => _elements;

        public Vector ViewPoint { get; set; }
        public double ViewWidth { get; set; }
        public double ViewHeight { get; set; }

        /// <summary>
        /// if true ViewPoint, ViewWidth, ViewHeight will be set automatically according the elements
        /// </summary>
        public bool AutoView { get; set; }
        public void Add<T>(T element)
            where T : struct, IGeometricElement
        {
            _elements.Add(element);
            CalcView();
        }

        [STAThread]
        public void Show(bool waitForClose = false)
        {
            var form = new VisualizationForm { Drawing = this };

            if (waitForClose)
                form.ShowDialog();
            else
                form.Show();
        }

        public IEnumerator<IGeometricElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public Image DrawImage(int width, int height)
        {
            var img = new Bitmap(width, height);

            using (var g = Graphics.FromImage(img))
            {
                foreach (var el in this)
                {
                    if (el is Vector)
                        DrawVector(g, (Vector)el);
                    else if (el is Segment)
                        DrawSegment(g, (Segment)el);
                    else
                        throw new NotImplementedException();


                }
            }

            return img;
        }

        private void CalcView()
        {
            var minX = double.MaxValue;
            var minY = double.MaxValue;
            var maxX = double.MinValue;
            var maxY = double.MinValue;

            foreach (var el in _elements)
            {
                if (el is Vector)
                {
                    minX = Math.Min(minX, ((Vector)el).X);
                    minY = Math.Min(minY, ((Vector)el).Y);

                    maxX = Math.Max(maxX, ((Vector)el).X);
                    maxY = Math.Max(maxY, ((Vector)el).Y);
                }
            }

            ViewPoint = new Vector((maxX - minX) / 2, (maxY - minY) / 2);

            ViewWidth = minX == maxX ? MarginFallback : (maxX - minX) * (MarginFactor + 1);
            ViewHeight = minY == maxY ? MarginFallback : (maxY - minY) * (MarginFactor + 1);
        }

        private Vector calcViewPos(Vector p, Graphics g)
        {
            var viewOffset = ViewPoint - new Vector(ViewWidth/2, ViewHeight/2);
            var relPos = p - viewOffset;

            var xFact = g.VisibleClipBounds.Width/ViewWidth;
            var yFact = g.VisibleClipBounds.Height/ViewHeight;

            return new Vector(relPos.X*xFact, relPos.Y*yFact);
        }

        private void DrawVector(Graphics g, Vector v)
        {
            v = calcViewPos(v,g);
            g.FillEllipse(Brushes.Black, (float)v.X, (float)v.Y, 2, 2);
        }

        private void DrawSegment(Graphics g, Segment s)
        {
            s = new Segment(calcViewPos(s.Start,g), calcViewPos(s.End,g));
            g.DrawLine(Pens.Black, (float)s.X1, (float)s.Y1, (float)s.X2, (float)s.Y2);
        }

    }
}
