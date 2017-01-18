using Android.Locations;
using System;

namespace TouchWalkthrough
{
    interface iServiceHandler
    {
        //int RANGE = 10; //meters
        Drop[] updateEventList(DateTime lastUpdate);
        Drop[] getEventsInRange(int range, Location position);
    }
}