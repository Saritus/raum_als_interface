using Android.Locations;
using System;
using System.Data;

namespace TouchWalkthrough
{
    public class Drop
    {
        // Internal settings
        public int id { get; private set; }
        public DateTime lastChange { get; private set; }

        // Creator settings
        public string name
        {
            get
            {
                return name;
            }
            set
            {
                lastChange = DateTime.Now;
                name = value;
            }
        }

        public Category category
        {
            get
            {
                return category;
            }
            set
            {
                lastChange = DateTime.Now;
                category = value;
            }
        }
        public string description
        {
            get
            {
                return description;
            }
            set
            {
                lastChange = DateTime.Now;
                description = value;
            }
        }

        public DateRange timeRange
        {
            get
            {
                return timeRange;
            }
            set
            {
                lastChange = DateTime.Now;
                timeRange = value;
            }
        }

        public ExtendedLocation location
        {
            get
            {
                return location;
            }
            set
            {
                lastChange = DateTime.Now;
                location = value;
            }
        }

        public string picturePath
        {
            get
            {
                return picturePath;
            }
            set
            {
                lastChange = DateTime.Now;
                picturePath = value;
            }
        }

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
            : this(id, name, category, description, startTime, endTime, location, null)
        {

        }

        public Drop(int id)
        {
            this.id = id;
        }

        public Drop()
        {

        }

        public bool save(string filename)
        {
            // TODO: save this drop to xml file
            XML.Save<Drop>(this, filename);
            return false;
        }

        public void show()
        {
            Console.WriteLine(id + ", " + name);
        }

        public void showDetail()
        {
            Console.WriteLine("Details: " + id + ", " + name + ", " + description);
        }
    }
}
