using Android.Locations;
using System;
using System.Text.RegularExpressions;

namespace TouchWalkthrough
{
    public class HTWLocation
    {
        public string name { get; set; }

        public Building building { get; set; }

        public int floor { get; set; }

        public string room { get; set; }

        public Location location { get; set; }

        public HTWLocation(string room)
        {
            name = room;

            Regex regex = new Regex("[A-Z][0-9]+[a-z]?");
            if (regex.IsMatch(room))
            {
                this.building = (Building)Enum.Parse(typeof(Building), room[0].ToString());
                this.floor = int.Parse(room[1].ToString());
                this.room = room.Substring(1);
            }
            else
            {
                // No regular room
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
            this.room = room;
        }

        public HTWLocation()
        {

        }

        public override string ToString()
        {
            return building.ToString() + " " + room;
        }
    }
}
