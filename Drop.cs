using System;
using Android.Locations;
using System.Data;

class Drop
{
    public enum type { Event, Idea };

    public String name { get; set; }

    public Location pos { get; set; }

    public DateTime start { get; set; }

    public string imagepath { get; set; }

    public Drop()
    {
        // TODO: create a new drop
    }

    public Drop(string xmlfile)
    {
        // TODO: load a drop from a xml file
    }

    public Drop(DataRow row)
    {
        // TODO: create a new Drop from a datarow
    }

    public bool save(string filename)
    {
        // TODO: save this drop to xml file
        XML.Save<Drop>(this, filename);
        return false;
    }
}