using Android.Locations;
using System;
using System.Text.RegularExpressions;

namespace TouchWalkthrough
{
    public class HTWLocation
    {
        public Building building { get; set; }

        public int floor { get; set; }

        public int room { get; set; }

        public HTWLocation(string room)
        {
            Regex regex = new Regex("[A-Z][0-9]+");
            if (regex.IsMatch(room))
            {
                this.building = (Building)Enum.Parse(typeof(Building), room[0].ToString());
                this.floor = int.Parse(room[1].ToString());
                this.room = int.Parse(room.Substring(1));
            }
            else
            {
                throw new Exception("Invalid room");
            }
        }

        public HTWLocation(char building, string room)
            : this((Building)Enum.Parse(typeof(Building), building.ToString()), room)
        {
        }

        public HTWLocation(Building building, string room)
        {
            this.building = building;
            this.floor = int.Parse(room[0].ToString());
            this.room = int.Parse(room);
        }

        public HTWLocation()
        {

        }
    }
}
