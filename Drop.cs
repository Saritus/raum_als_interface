using System;
using Android.Locations;

class Drop
{
    public enum type { Event, Idea };

    public String name { get; set; }

    public Location pos { get; set; }

    public DateTime start { get; set; }

    public string imagepath { get; set; }

    public bool save(string filename)
    {
        // TODO: save this drop to xml file
        XML.Save<Drop>(this, filename);
        return false;
    }
}