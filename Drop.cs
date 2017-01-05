using System;
using Android.Locations;

abstract class Drop
{
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
}