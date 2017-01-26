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
        public string name { get; set; }

        public Category category
        {
            get
            {
                return category;
            }
            set
            {
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
                description = value;
            }
        }

        public DateTime startTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        public HTWLocation location
        {
            get
            {
                return location;
            }
            set
            {
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
                picturePath = value;
            }
        }

        // User settings
        public bool followed { get; set; }
        public bool ignored { get; set; }

        public Drop(int id, string name, Category category, string description, DateTime startTime, HTWLocation location, string picturePath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.location = location;
            this.picturePath = picturePath;
        }

        public void update(Drop newDrop)
        {
            this.id = newDrop.id;
            this.name = newDrop.name;
            this.description = newDrop.description;
            this.category = newDrop.category;
            this.startTime = newDrop.startTime;
            this.location = newDrop.location;
            this.picturePath = newDrop.picturePath;
        }

        public Drop(int id, string name, Category category, string description, DateTime startTime, HTWLocation location)
            : this(id, name, category, description, startTime, location, null)
        {

        }

        public Drop(int id, string name, Category category, string description, DateTime startTime)
            : this(id, name, category, description, startTime, null, null)
        {

        }

        public Drop(int id)
        {
            this.id = id;
        }

        public Drop()
        {

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
