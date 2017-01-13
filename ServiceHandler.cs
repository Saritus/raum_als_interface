using Android.Locations;
using System;

namespace TouchWalkthrough
{
    interface ServiceHandler
    {
        //int RANGE = 10; //meters
        Drop[] updateEventList(DateTime lastUpdate);
        Drop[] getEventsInRange(int range, Location position);
    }
}