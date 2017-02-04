using Android.Locations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace TouchWalkthrough
{
    public class HTWLocation
    {
        static Dictionary<string, Point> roomTable;

        public string name { get; set; }

        public Building building { get; set; }

        public int floor { get; set; }

        public string room { get; set; }

        public Location location { get; set; }

        public Point position { get; set; }

        public HTWLocation(string room)
        {
            if (roomTable == null)
            {
                fillDictionary();
            }

            //position = roomTable[room];
            Point pos;
            roomTable.TryGetValue(room, out pos);
            position = pos;

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

        public HTWLocation(Building building, string room)
            : this(building.ToString() + room)
        {
        }

        public HTWLocation()
        {

        }

        public override string ToString()
        {
            return name;
        }

        private void fillDictionary()
        {
            roomTable = new Dictionary<string, Point>();
            roomTable["Z017"] = new Point();
            roomTable["Z102"] = new Point();
            roomTable["Z103"] = new Point();
            roomTable["Z104"] = new Point();
            roomTable["Z105"] = new Point();
            roomTable["Z106"] = new Point();
            roomTable["Z107"] = new Point(708, 1945);
            roomTable["Z113a"] = new Point(135, 1819); // Cafeteria
            roomTable["Z122"] = new Point();
            roomTable["Z123"] = new Point();
            roomTable["Z124"] = new Point();
            roomTable["Z125"] = new Point();
            roomTable["Z126"] = new Point();
            roomTable["Z130"] = new Point();
            roomTable["Z133"] = new Point();
            roomTable["Z135"] = new Point();
            roomTable["Z136"] = new Point();
            roomTable["Z136a"] = new Point();
            roomTable["Z136b"] = new Point(507, 519);
            roomTable["Z136c"] = new Point(479, 689);
            roomTable["Z137"] = new Point();
            roomTable["Z138"] = new Point();
            roomTable["Z139"] = new Point();
            roomTable["Z140"] = new Point();
            roomTable["Z141"] = new Point();
            roomTable["Z146a"] = new Point();
            roomTable["Z146b"] = new Point();
            roomTable["Z147"] = new Point();
            roomTable["Z148"] = new Point();
            roomTable["Z149"] = new Point();
            roomTable["Z150"] = new Point();
            roomTable["Z151"] = new Point();
            roomTable["Z153"] = new Point();
            roomTable["Z154a"] = new Point();
            roomTable["Z154b"] = new Point();
            roomTable["Z155"] = new Point();
            roomTable["Z156"] = new Point();
            roomTable["Z208"] = new Point();
            roomTable["Z211"] = new Point();
            roomTable["Z254"] = new Point();
            roomTable["Z302"] = new Point();
            roomTable["Z308"] = new Point();
            roomTable["Z312"] = new Point();
            roomTable["Z354"] = new Point();
            roomTable["Z355"] = new Point();
            roomTable["Z407"] = new Point();
            roomTable["Z410"] = new Point();
            roomTable["Z414"] = new Point();
            roomTable["Z455"] = new Point();
            roomTable["Z624"] = new Point();
            roomTable["Z628"] = new Point();
            roomTable["Z701"] = new Point();
            roomTable["Z722"] = new Point();
            roomTable["Z801"] = new Point();
            roomTable["Z817"] = new Point();
            roomTable["Z822"] = new Point();
            roomTable["Z823"] = new Point();
            roomTable["Z824"] = new Point();
            roomTable["Z834"] = new Point();
            roomTable["Z841"] = new Point();
            roomTable["Z901"] = new Point();
            roomTable["Z902"] = new Point(479, 689); // nicht sicher
            roomTable["Z903"] = new Point();
            roomTable["Z907"] = new Point();
            roomTable["Z908"] = new Point();
        }
    }
}
