using Android.Locations;
using System;

namespace TouchWalkthrough
{
    public class HTWLocation : Location
    {
        public Building building { get; set; }
        public int floor { get; set; }

        public HTWLocation(String provider) : base(provider)
        {

        }

        public HTWLocation(HTWLocation l) : base(l)
        {

        }

        public HTWLocation() : base("")
        {
        }
    }
}
