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
using Android.Locations;

namespace TouchWalkthrough
{
    interface ServiceHandler
    {
        static int RANGE = 10; //meters
        public Drop[] updateEventList(DateTime lastUpdate);
        public Drop[] getEventsInRange(int range, Location position);
    }
}