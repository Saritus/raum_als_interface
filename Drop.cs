using System;
using Android.Locations;

class Drop
{
    public enum type { Event, Idea };

    public String name
    {
        get { return name; }
        set { name = value; }
    }

    public Location pos
    {
        get { return pos; }
        set { pos = value; }
    }

    public DateTime start
    {
        get { return start; }
        set { start = value; }
    }

    public string imagepath
    {
        get { return imagepath; }
        set { imagepath = value; }
    }

    public bool save()
    {
        // TODO: save this drop to xml file
        return false;
    }
}