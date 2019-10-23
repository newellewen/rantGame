using System;
using Rant;
using Rant.Vocabulary; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Rant.Core.ObjectModel;

namespace ProceduralTextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Rant engine...");
            
            RantEngine rantEngine = RantLoader.StartEngine();             
            Console.WriteLine("Engine loaded");
            Console.WriteLine(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " " + DateTime.Now.Second.ToString() + "." + DateTime.Now.Millisecond.ToString());

            Menu mainMenu = new Menu(new List<string> { "New Player", "New Map", "Map Details", "Start Game", "Rant Test", "Exit" });

            Player player = new Player();
            Map map = null; 


            while (mainMenu.options[mainMenu.menuChoice] != "Exit")
            {
                mainMenu.ShowMenu();

                switch (mainMenu.options[mainMenu.menuChoice])
                {
                    case "New Player":
                        player.NewPlayer(); 
                        break; 
                    case "New Map":
                        map = Map.NewMap(); 
                        break;
                    case "Map Details":
                        try
                        {
                            map.ShowMapDetails();
                        }
                        catch { }
                        break;
                    case "Start Game":
                        StartGame(); 
                        break;
                    case "Rant Test":
                        RantTesting();
                        break;

                }
            }

            void RantTesting()
            {
                Menu rantMenu = new Menu(new List<string> { "Go", "Exit" }); 

                while (rantMenu.options[rantMenu.menuChoice] != "Exit")
                {
                    rantMenu.ShowMenu();
                    switch (rantMenu.options[rantMenu.menuChoice])
                    {
                        case "Go":

                            List<Character> cast = new List<Character>();
                            List<string> castNames = new List<string>(); 

                            for (int i = 0; i < 10; i++)
                            {
                                cast.Add(new Character(i));
                                castNames.Add(cast[i].name);
                            }

                            castNames.Add("Exit");

                            Menu castMenu = new Menu(castNames); 

                            while (castMenu.options[castMenu.menuChoice] != "Exit")
                            {
                                castMenu.ShowMenu(); 
                                if (castMenu.options[castMenu.menuChoice] != "Exit")
                                {
                                    Console.WriteLine("Name: " + cast[castMenu.menuChoice].name);
                                    Console.WriteLine("Hair Color: " + cast[castMenu.menuChoice].hairColor);
                                    Console.WriteLine("Action: " + cast[castMenu.menuChoice].action);
                                    Console.WriteLine("Action Item: " + cast[castMenu.menuChoice].actionItem);
                                }
                            }
                            break; 
                    }
                }
            }


            void StartGame()
            {
                Menu gameMenu = new Menu(new List<string> { "Examine", "Move", "Exit Game" });

                player.location = map.startingRoom;
                player.GetExits(); 

                while (gameMenu.options[gameMenu.menuChoice] != "Exit Game")
                {
                    gameMenu.ShowMenu(); 

                    switch (gameMenu.options[gameMenu.menuChoice])
                    {
                        case "Examine":
                            player.Examine();
                            break;
                        case "Move":
                            player.Move();
                            break;
                    }
                }
            }            

            


            
        }
    }
}
