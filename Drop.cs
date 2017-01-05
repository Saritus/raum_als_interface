using System;
using Android.Locations;

namespace TouchWalkthrough
{
    abstract class Drop
    {
        public String name
        {
            get { return name; }
            set { name = value; }
        }

        public Location pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public DateTime start
        {
            get { return start; }
            set { start = value; }
        }

        public abstract bool saveToFile();
    }
}