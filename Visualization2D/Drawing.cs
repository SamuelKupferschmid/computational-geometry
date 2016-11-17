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
using Point = Geometry2D.Point;

namespace Visualization2D
{
    public class Drawing : IEnumerable<IGeometricElement>
    {
        public Drawing()
        {
            ViewPoint = new Point();
            AutoView = true;
        }

        private readonly List<IGeometricElement> _elements = new List<IGeometricElement>();

        private const double MarginFactor = 0.2;
        private const double MarginFallback = 10;

        [Browsable(true)]
        public IEnumerable<IGeometricElement> Elements => _elements;

        public Point ViewPoint { get; set; }
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
            calcView();
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
                    if (el is Point)
                        drawPoint(g, (Point)el);
                    else if (el is Segment)
                        drawSegment(g, (Segment)el);
                    else
                        throw new NotImplementedException();


                }
            }

            return img;
        }

        private void calcView()
        {
            var minX = double.MaxValue;
            var minY = double.MaxValue;
            var maxX = double.MinValue;
            var maxY = double.MinValue;

            foreach (var el in _elements)
            {
                if (el is Point)
                {
                    minX = Math.Min(minX, ((Point)el).X);
                    minY = Math.Min(minY, ((Point)el).Y);

                    maxX = Math.Max(maxX, ((Point)el).X);
                    maxY = Math.Max(maxY, ((Point)el).Y);
                }
            }

            ViewPoint = new Point((maxX - minX) / 2, (maxY - minY) / 2);

            ViewWidth = minX == maxX ? MarginFallback : (maxX - minX) * (MarginFactor + 1);
            ViewHeight = minY == maxY ? MarginFallback : (maxY - minY) * (MarginFactor + 1);
        }

        private Point calcViewPos(Point p, Graphics g)
        {
            return p;
        }

        private void drawPoint(Graphics g, Point p)
        {
            p = calcViewPos(p);
            g.FillEllipse(Brushes.Black, (float)p.X, (float)p.Y, 2, 2);
        }

        private void drawSegment(Graphics g, Segment s)
        {
            s = new Segment(calcViewPos(s.Start), calcViewPos(s.End));
            g.DrawLine(Pens.Black, (float)s.X1, (float)s.Y1, (float)s.X2, (float)s.Y2);
        }

    }
}
