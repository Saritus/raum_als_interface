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
    public class ExtendedLocation : Location{
	    private Building building 	{ get; set; }
	    private int floor 			{ get; set; }
    }
}
