using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralTextAdventure
{
    public class Player
    {
        public string name;
        public Room location;
        public List<string> availableExits; 

        public void NewPlayer()
        {
            Console.WriteLine(Environment.NewLine + "Enter a name:");
            this.name = Console.ReadLine(); 
        }

        public void Move()
        {
            Console.WriteLine(Environment.NewLine + "Available Exits:"); 
            foreach(string exit in this.availableExits)
            {
                Console.WriteLine("    " + exit); 
            }

            Console.WriteLine("What direction do you want to move?");
            string direction = Console.ReadLine(); 

            try
            {
                Room newLocation = this.location.exits.Find(exit => exit.Key == direction).Value; 
                if (newLocation == null)
                {
                    throw new Exception(); 
                }
                this.location = newLocation;
                GetExits(); 
            }
            catch
            {
                Console.WriteLine("You can't move in that direction."); 
            }
        }

        public void Examine()
        {
            this.location.ShowRoom(); 
        }

        public void GetExits()
        {
            this.availableExits = new List<string>(); 
            foreach (KeyValuePair<string, Room> exit in this.location.exits)
            {
                this.availableExits.Add(exit.Key); 
            }
        }
    
    }
}
