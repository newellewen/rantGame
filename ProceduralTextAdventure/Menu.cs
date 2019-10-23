using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralTextAdventure
{
    public class Menu
    {
        public Menu(List<string> _options)
        {
            options = _options;
        }

        public List<string> options;

        public int menuChoice;

        public void ShowMenu()
        {
            Console.WriteLine(Environment.NewLine + "Choose from the following options:");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine(String.Format("{0} - {1}", i + 1, this.options[i]));
            }

            try
            {
                Console.WriteLine(Environment.NewLine + "Enter a number from 1 to " + this.options.Count);
                this.menuChoice = Int16.Parse(Console.ReadLine()) - 1;
                if (this.menuChoice < 0 || this.menuChoice > this.options.Count - 1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Try Again");
                this.ShowMenu();
            }
        }
    }
}
