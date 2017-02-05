using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TouchWalkthrough
{
    [Serializable()]
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(Android.Graphics.Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        public Point(int x, int y)
            : this(new Android.Graphics.Point(x, y))
        {
        }

        public Point()
            : this(new Android.Graphics.Point())
        {
        }
    }
}