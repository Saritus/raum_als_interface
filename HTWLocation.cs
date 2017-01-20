using Android.Locations;
using System;

namespace TouchWalkthrough
{
    public class HTWLocation
    {
        public Building building { get; set; }
        public int floor { get; set; }

        public int room { get; set; }

        public HTWLocation(string room)
        {

        }

        public HTWLocation()
        {

        }
    }
}
