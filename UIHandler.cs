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

namespace TouchWalkthrough
{
    interface UIHandler{
	    private List<Drop> allEvents {get; set;}
	
	    public Drop[] getEvents();
	    public Drop[] getFilteredEvents(Category[] filters);
	    public Drop[] getFollowedEvents();
	
	    public void showEvents();
	    public void filter(Category[] filter);
	    public void ignoreEvent(Drop ev);
	    public void followEvent(Drop ev);
	    public void showEventDetail(Drop ev);
    }
}