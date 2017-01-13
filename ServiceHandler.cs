using Android.Locations;
using System;

namespace TouchWalkthrough
{
    interface ServiceHandler
    {
        static int RANGE = 10; //meters
        public Drop[] updateEventList(DateTime lastUpdate);
        public Drop[] getEventsInRange(int range, Location position);
    }
}