using Android.Content;
using Android.Graphics;
using Android.Widget;
using System;

namespace TouchWalkthrough
{
    public class Drop
    {
        // Internal settings
        public Guid id { get; private set; }
        public DateTime lastChange { get; private set; }

        // Creator settings
        public string name { get; set; }

        public Category category { get; set; }
        public string description { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public HTWLocation location { get; set; }

        public string picturePath { get; set; }

        // User settings
        public bool followed { get; set; }
        public bool ignored { get; set; }

        public Drop(Guid id, string name, Category category, string description, DateTime startTime, DateTime endTime, HTWLocation location, string picturePath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.picturePath = picturePath;
            this.lastChange = DateTime.Now;

            ImageStorage.Instance.addURL(picturePath);
        }

        public Drop(string name, Category category, string description, DateTime startTime, DateTime endTime, HTWLocation location, string picturePath)
            : this(Guid.NewGuid(), name, category, description, startTime, endTime, location, picturePath)
        {

        }

        public Drop(string name, Category category, DateTime startTime, DateTime endTime, HTWLocation location, string picturePath)
           : this(Guid.NewGuid(), name, category, "", startTime, endTime, location, picturePath)
        {

        }

        public Drop(string name, Category category, string description, DateTime startTime, HTWLocation location, string picturePath)
            : this(Guid.NewGuid(), name, category, description, startTime, startTime.AddHours(1), location, picturePath)
        {

        }

        public Drop(string name, Category category, DateTime startTime, HTWLocation location, string picturePath)
            : this(Guid.NewGuid(), name, category, "", startTime, startTime.AddHours(1), location, picturePath)
        {

        }

        public Drop(string name, Category category, string description, DateTime startTime, DateTime endTime, HTWLocation location)
            : this(Guid.NewGuid(), name, category, description, startTime, endTime, location, null)
        {

        }

        public Drop(string name, Category category, string description, DateTime startTime, HTWLocation location)
            : this(Guid.NewGuid(), name, category, description, startTime, startTime.AddHours(1), location, null)
        {

        }

        public Drop(string name, Category category, DateTime startTime, DateTime endTime, HTWLocation location)
            : this(Guid.NewGuid(), name, category, "", startTime, endTime, location, null)
        {

        }

        public Drop(string name, Category category, DateTime startTime, HTWLocation location)
            : this(Guid.NewGuid(), name, category, "", startTime, startTime.AddHours(1), location, null)
        {

        }

        public void update(Drop newDrop)
        {
            this.id = newDrop.id;
            this.name = newDrop.name;
            this.description = newDrop.description;
            this.category = newDrop.category;
            this.startTime = newDrop.startTime;
            this.endTime = newDrop.endTime;
            this.location = newDrop.location;
            this.picturePath = newDrop.picturePath;
        }

        public int GetIconId(string type)
        {
            switch (category)
            {
                case Category.EVENT:
                    switch (type)
                    {
                        case "icon":
                            return Resource.Drawable.icon_hap1;
                        case "art":
                            return Resource.Drawable.dropart1;
                        default:
                            return Resource.Drawable.icon_hap1;
                    }
                case Category.VOTE:
                    switch (type)
                    {
                        case "icon":
                            return Resource.Drawable.icon_hap3;
                        case "art":
                            return Resource.Drawable.dropart3;
                        default:
                            return Resource.Drawable.icon_hap3;
                    }
                case Category.WARNING:
                    switch (type)
                    {
                        case "icon":
                            return Resource.Drawable.icon_hap2;
                        case "art":
                            return Resource.Drawable.dropart2;
                        default:
                            return Resource.Drawable.icon_hap2;
                    }
                default:
                    return -1;
            }
        }

        public TableItem ToTableItem()
        {
            TableItem tableitem = new TableItem();

            tableitem.Heading = name;

            tableitem.SubHeading = location.ToString() + "; " + startTime.ToString("dd.MM.yyyy");

            tableitem.ImageResourceId = GetIconId("icon");

            tableitem.id = id;

            return tableitem;
        }

        public ImageButton ToImageButton(Context context)
        {
            ImageButton drop_button = new ImageButton(context);

            // Aussehen
            drop_button.SetImageResource(GetIconId("icon"));
            drop_button.SetBackgroundColor(Color.Transparent);

            return drop_button;
        }
    }
}
