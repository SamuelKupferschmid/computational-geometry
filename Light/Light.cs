//code by samuel.kupferschmid@students.fhnw.ch
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Threading;
using Geometry2D;
using Visualization2D;

namespace Light
{
    class Light
    {
        static readonly IEnumerator<string> inp = File.ReadLines("light.in").SelectMany(line => line.Split(' ')).GetEnumerator();
        static string Next() { inp.MoveNext(); return inp.Current; }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            using (var outp = new StreamWriter("light.out"))
            {
                var drawing = new Drawing();
                var n = int.Parse(Next());
                var vectors = new Vector[n];
                var move = new Vector(0,-1);
                for (var i = 0; i < n; i++)
                {
                    var v = new Vector(double.Parse(Next()), double.Parse(Next()));
                    vectors[i] = v;

                    if (i > 0)
                    {
                        var s = new Segment(vectors[i - 1], vectors[i]);
                        drawing.Add(s);
                        drawing.Add(s + move);
                    }
                }

                drawing.Add(new Vector(3,5));
                drawing.Add(new Line(Vector.Null, new Vector(3,2)));
                drawing.Add(new Ray(new Vector(1,1),new Vector(-0.1,4)));
                //outp.Write("solution");



                drawing.Show(true);
            }
        }


    }
}
