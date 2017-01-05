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
    class Event
    {
        public String name { get; set; }
        public Location pos { get; set; }
        public DateTime start { get; set; }

        public Event()
        {
        }

        public bool saveToFile(String filename)
        {
            return true;
        }
    }
}