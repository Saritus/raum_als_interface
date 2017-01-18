using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchWalkthrough
{

    class Drop
    {
        private int id;
        private string name;
        private string description;
        private Category category;

        private DateTime startTime;
        private DateTime endTime;

        private ExtendedLocation location;

        private bool followed;
        private bool ignored;

        private string picturePath;
        
        public Drop(int id, string name, string description, Category category, DateTime startTime, DateTime endTime, ExtendedLocation Location, bool f, bool i) 
            : this(id, name, description, category, startTime, endTime, Location, f, i, "")
        {
        }

        public Drop(int id, string name, string description, Category category, DateTime startTime, DateTime endTime, ExtendedLocation location, bool f, bool i, string picPath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.followed = f;
            this.ignored = i;
            this.picturePath = picPath;
        }

        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public string getDescription()
        {
            return description;
        }

        public Category getCategory()
        {
            return category;
        }

        public DateTime getStartTime()
        {
            return startTime;
        }

        public DateTime getEndTime()
        {
            return endTime;
        }

        public ExtendedLocation getLocation()
        {
            return null;
        }

        public bool isFollowed()
        {
            return followed;
        }

        public void follow(bool i)
        {
            this.followed = i;
        }

        public bool isIgnored()
        {
            return ignored;
        }

        public void ignore(bool i)
        {
            this.ignored = i;
        }

        public string getPicturePath()
        {
            return picturePath;
        }
    }
}
