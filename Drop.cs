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

        public Category category { get; set; }
        public string description { get; set; }

        public DateTime startTime { get; set; }

        public HTWLocation location { get; set; }

        public string picturePath { get; set; }

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

        public Drop(int id, string name, Category category, DateTime startTime, HTWLocation location)
            : this(id, name, category, "", startTime, location, null)
        {

        }

        public Drop(int id, string name, Category category, string description, DateTime startTime)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
        }

        public Drop(int id, string name, Category category, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
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

        public TableItem ToTableItem()
        {
            TableItem tableitem = new TableItem();

            tableitem.Heading = name;

            tableitem.SubHeading = location.ToString() + "; " + startTime.ToString("dd.MM.yyyy");

            switch (category)
            {
                case Category.EVENT:
                    tableitem.ImageResourceId = Resource.Drawable.icon_hap1;
                    break;
                case Category.VOTE:
                    tableitem.ImageResourceId = Resource.Drawable.icon_hap3;
                    break;
                case Category.WARNING:
                    tableitem.ImageResourceId = Resource.Drawable.icon_hap2;
                    break;
            }

            return tableitem;
        }
    }
}
