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

        public HTWLocation(string name, int x, int y)
        {
            position = new Point(x, y);

            this.name = name;

            building = Building.Z;
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
            roomTable["Z017"] = new Point(); // Wo soll der sein?
            roomTable["Z102"] = new Point(981, 1763);
            roomTable["Z103"] = new Point(986, 1944);
            roomTable["Z104"] = new Point(873, 1928);
            roomTable["Z105"] = new Point(854, 1736);
            roomTable["Z106"] = new Point(785, 1725);
            roomTable["Z107"] = new Point(708, 1945);
            roomTable["Z113a"] = new Point(135, 1819); // Cafeteria
            roomTable["Z122"] = new Point(609, 1228);
            roomTable["Z123"] = new Point(598, 1296);
            roomTable["Z124"] = new Point(588, 1367);
            roomTable["Z125"] = new Point(577, 1431);
            roomTable["Z126"] = new Point(562, 1529);
            roomTable["Z130"] = new Point(332, 1121);
            roomTable["Z133"] = new Point(494, 867);
            roomTable["Z135"] = new Point(364, 911);
            roomTable["Z136"] = new Point(401, 816);
            roomTable["Z136a"] = new Point(524, 393);
            roomTable["Z136b"] = new Point(507, 519);
            roomTable["Z136c"] = new Point(479, 689);
            roomTable["Z137"] = new Point(736, 426);
            roomTable["Z138"] = new Point(725, 493);
            roomTable["Z139"] = new Point(713, 565);
            roomTable["Z140"] = new Point(703, 628);
            roomTable["Z141"] = new Point(690, 722);
            roomTable["Z146a"] = new Point(784, 222);
            roomTable["Z146b"] = new Point(611, 193);
            roomTable["Z147"] = new Point(381, 275);
            roomTable["Z148"] = new Point(303, 261);
            roomTable["Z149"] = new Point(314, 175);
            roomTable["Z150"] = new Point(329, 94);
            roomTable["Z151"] = new Point(407, 103);
            roomTable["Z153"] = new Point(904, 181);
            roomTable["Z154a"] = new Point(973, 190);
            roomTable["Z154b"] = new Point(1047, 202);
            roomTable["Z155"] = new Point(1021, 374);
            roomTable["Z156"] = new Point(947, 362);
            roomTable["Z208"] = new Point();
            roomTable["Z211"] = new Point();
            roomTable["Z241"] = new Point(524, 393); // nicht sicher
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
            roomTable["Z903"] = new Point(507, 519); // nicht sicher
            roomTable["Z907"] = new Point();
            roomTable["Z908"] = new Point();
        }
    }
}
