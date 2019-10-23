using System;
using System.Collections.Generic;
using Rant;
using Rant.Vocabulary; 

namespace ProceduralTextAdventure
{
    public class Room
    {
        public string name;
        public string description;
        public int roomId;
        public List<KeyValuePair<string, Room>> exits = new List<KeyValuePair<string, Room>>();

        private RantEngine rantEngine = RantLoader.StartEngine(); 

        public void ShowRoom()
        {
            RantProgram program = RantProgram.CompileString(@"You <descriptor-room_arrived>");
            RantOutput output = rantEngine.Do(program);

            string roomArrive = output.ToString();

            Console.WriteLine(Environment.NewLine + roomArrive + " " + this.description); 
        }

        public void ShowExits()
        {
            foreach(KeyValuePair<string, Room> exit in this.exits)
            {
                Console.WriteLine(exit.Key); 
            }
        }


    }
}
