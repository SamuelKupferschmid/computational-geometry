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
            ViewSize = default(Segment);
            AutoView = true;
        }

        private readonly List<IGeometricElement> _elements = new List<IGeometricElement>();

        private const double MarginFactor = 0.2;

        [Browsable(true)]
        public IEnumerable<IGeometricElement> Elements => _elements;

        public Segment ViewSize { get; set; }

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

        /// <summary>
        /// Draws an Image which fits into the given width and height keeping the Drawings ratio
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public void DrawGraphics(Graphics g)
        {
            double width = g.VisibleClipBounds.Width;
            double height = g.VisibleClipBounds.Height;

            var cRatio = width / height;
            var dRation = ViewSize.X / ViewSize.Y;

            var f = cRatio > dRation ? height / ViewSize.Y : width / ViewSize.X;
            var size = (ViewSize.End - ViewSize.Start) * f;
            var offset = (new Vector(width,height) - size) / 2;
            g.FillRectangle(Brushes.DeepSkyBlue,g.VisibleClipBounds);
            g.FillRectangle(Brushes.CornflowerBlue, new Rectangle((int)offset.X,(int)offset.Y,(int)size.X,(int)size.Y));
            foreach (var el in this)
            {
                if (el is Vector)
                    DrawVector(g, (Vector)el, offset, f);
                else if (el is Segment)
                    DrawSegment(g, (Segment)el, offset, f);
            }
        }

        private void DrawVector(Graphics g, Vector v, Vector offset, double factor)
        {
            v = calcImageVector(v, offset, factor);
            g.FillEllipse(Brushes.Black, (float)v.X, g.VisibleClipBounds.Height - (float)v.Y, 2, 2);
        }

        private void DrawSegment(Graphics g, Segment s, Vector offset, double factor)
        {
            s = new Segment(calcImageVector(s.Start, offset, factor), calcImageVector(s.End, offset, factor));
            g.DrawLine(Pens.DarkGreen, (float)s.X1, g.VisibleClipBounds.Height - (float)s.Y1, (float)s.X2, g.VisibleClipBounds.Height - (float)s.Y2);
        }

        private Vector calcImageVector(Vector v, Vector offset, double factor) => v * factor + offset;

        private void CalcView()
        {
            var minX = double.MaxValue;
            var minY = double.MaxValue;
            var maxX = double.MinValue;
            var maxY = double.MinValue;

            Action<Vector> adjustFrame = (Vector v) =>
            {
                minX = Math.Min(minX, v.X);
                minY = Math.Min(minY, v.Y);
                maxX = Math.Max(maxX, v.X);
                maxY = Math.Max(maxY, v.Y);
            };

            foreach (var el in _elements)
            {
                if (el is Vector)
                {
                    adjustFrame((Vector)el);
                }
                else if (el is Segment)
                {
                    adjustFrame(((Segment)el).Start);
                    adjustFrame(((Segment)el).End);
                }
            }

            var marginX = (maxX - minX) * MarginFactor / 2;
            var marginY = (maxY - minY) * MarginFactor / 2;

            var start = new Vector(minX - marginX, minY - marginY);
            var end = new Vector(maxX + marginX, maxY + marginY);

            ViewSize = new Segment(start, end - start);
        }

    }
}
