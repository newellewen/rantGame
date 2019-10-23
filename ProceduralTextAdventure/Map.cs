using System;
using System.Collections.Generic;
using Rant;
using Rant.Vocabulary; 

namespace ProceduralTextAdventure
{
    public class Map
    {
        public List<Room> rooms = new List<Room>();
        public Room startingRoom = new Room();
        private static RantEngine rantEngine = RantLoader.StartEngine();
        private static Random rnd = new Random();

        public Map(List<Room> _rooms)
        {
            rooms = _rooms;
            startingRoom = rooms.Find(r => r.roomId == 1); 
        }

        public static Map NewMap()
        {
            Map newMap = null; 

            Console.WriteLine(Environment.NewLine + "Enter a number from 1 to 50: ");
            int roomCount = 0;
            try
            {
                roomCount = Int16.Parse(Console.ReadLine());
                if (roomCount < 1 || roomCount > 50)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine(Environment.NewLine + "Try again");
            }

            newMap = GenerateMap(roomCount);
            return newMap; 
        }

        private static Map GenerateMap(int roomCount)
        {
            Map _map = new Map(GetRooms(roomCount));

            _map.SetExits(GetExits(_map));
            return _map;
        }

        private static List<Room> GetRooms(int roomCount)
        {

            RantProgram program = RantProgram.CompileString(@"<adj> <noun-indoor>");
            RantOutput output = null;
            List<Room> rooms = new List<Room>();

            for (int i = 0; i < roomCount; i++)
            {
                output = rantEngine.Do(program);
                Room newRoom = new Room();
                newRoom.roomId = i + 1;
                newRoom.name = output.ToString();
                newRoom.description = output.ToString();
                rooms.Add(newRoom);
            }
            return rooms;
        }

        private static List<Tuple<int, string, int>> GetExits(Map _map)
        {
            List<Tuple<int, string, int>> exits = new List<Tuple<int, string, int>>();

            foreach (Room room in _map.rooms)
            {
                List<string> directions = GetDirections(new List<string> { "North", "South", "East", "West" });
                foreach (string direction in directions)
                {
                    exits.Add(new Tuple<int, string, int>(room.roomId, direction, rnd.Next(_map.rooms.Count)));
                }
            }
            return exits;
        }

        private static List<string> GetDirections(List<string> _directions)
        {
            List<string> exits = new List<string>();
            while (exits.Count < rnd.Next(1, _directions.Count))
            {
                string exit = _directions[rnd.Next(_directions.Count - 1)];
                if (exits.Find(e => e == exit) == null)
                {
                    exits.Add(exit);
                }
            }
            return exits;
        }

        public void ShowMapDetails()
        {
            int exits = 0; 
            foreach(Room room in this.rooms)
            {
                exits += room.exits.Count;
            }
        }

        public void SetExits(List<Tuple<int, string, int>> exits)
        {
            foreach (Room room in this.rooms)
            {
                foreach(Tuple<int, string, int> exit in exits)
                {
                    if (exit.Item1 == room.roomId)
                    {
                        Room exitRoom = this.rooms.Find(r => r.roomId == exit.Item3);
                        room.exits.Add(new KeyValuePair<string, Room>(exit.Item2, exitRoom)); 
                    }
                }
            }
        }
    }
}
