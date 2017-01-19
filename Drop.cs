using Android.Locations;
using System;
using System.Data;

namespace TouchWalkthrough
{
    class Drop
    {

        // Global settings
        public int id { get; set; }
        public string name { get; set; }

        public Category category { get; set; }
        public string description { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public ExtendedLocation location { get; set; }

        public string picturePath { get; set; }

        // User settings
        public bool followed { get; set; }
        public bool ignored { get; set; }

        public Drop(int id, string name, Category category, string description, DateTime startTime, DateTime endTime, ExtendedLocation location, string picturePath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.picturePath = picturePath;
        }

        public Drop(int id, string name, Category category, string description, DateTime startTime, DateTime endTime, ExtendedLocation location)
            : this(id, name, category, description, startTime, endTime, location, "")
        {

        }

        public Drop(int id)
        {
            this.id = id;
        }

        public Drop(string filename)
        {
            // TODO: load a drop from a xml file
        }

        public Drop(DataRow row)
        {
            // TODO: create a new Drop from a datarow (SQL)
        }

        public bool save(string filename)
        {
            // TODO: save this drop to xml file
            XML.Save<Drop>(this, filename);
            return false;
        }
    }
}
