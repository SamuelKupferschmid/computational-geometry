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
        }

        private readonly List<IGeometricElement> _elements = new List<IGeometricElement>();

        [Browsable(true)]
        public IEnumerable<IGeometricElement> Elements => _elements;

        public Point ViewPoint { get; set; }
        public double ViewWidth { get; set; }
        public double ViewHeight { get; set; }

        public void Add<T>(T element)
            where T : struct, IGeometricElement
        {
            _elements.Add(element);
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
                    if(el is Point)
                        drawPoint(g,(Point)el);
                    else
                        throw new NotImplementedException();


                }
            }

            return img;
        }

        private void drawPoint(Graphics g, Point p)
        {
            g.FillEllipse(Brushes.Black, (float)p.X,(float)p.Y,2,2);
        }

    }
}
