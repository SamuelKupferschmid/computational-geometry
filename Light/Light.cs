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
                //your code here
                //var a=int.Parse(Next());
                //outp.Write("solution");

                var drawing = new Drawing
                {
                    new Point(3, 5),
                    new Segment(new Point(3,60),new Point(500,6))
                };



                drawing.Show(true);
            }
        }

        
    }
}
