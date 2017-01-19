using Android.Locations;
using System;

namespace TouchWalkthrough
{
    public class ExtendedLocation : Location
    {
        public Building building { get; set; }
        public int floor { get; set; }

        public ExtendedLocation(String provider) : base(provider)
        {

        }

        public ExtendedLocation(ExtendedLocation l) : base(l)
        {

        }

        public ExtendedLocation() : base("")
        {
        }
    }
}
