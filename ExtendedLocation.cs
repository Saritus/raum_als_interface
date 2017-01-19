using Android.Locations;
using System;

namespace TouchWalkthrough
{
    public class ExtendedLocation : Location
    {
        private Building building { get; set; }
        private int floor { get; set; }


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
