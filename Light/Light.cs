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
                var n=int.Parse(Next());
                var points = new Point[n];

                for (var i = 0; i < n; i++)
                {
                    var p = new Point(double.Parse(Next()), double.Parse(Next()));
                    points[i] = p;
                    drawing.Add(p);
                }
                //outp.Write("solution");



                drawing.Show(true);
            }
        }

        
    }
}
