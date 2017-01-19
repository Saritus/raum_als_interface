using Android.Locations;
using System;
using System.Data;

namespace TouchWalkthrough
{
    class Drop
    {

        // Global settings
        private int id { get; set; }
        private string name { get; set; }

        private Category category { get; set; }
        private string description { get; set; }

        private DateTime startTime { get; set; }
        private DateTime endTime { get; set; }

        private ExtendedLocation location { get; set; }

        private string picturePath { get; set; }

        // User settings
        private bool followed { get; set; }
        private bool ignored { get; set; }

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
