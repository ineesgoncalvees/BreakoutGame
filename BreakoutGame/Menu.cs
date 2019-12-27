using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    public class Menu
    {
        // console dimensions
        private int x = 100, y = 60;

        private string title = "Breakout";

        private string names = "Diana Nóia & Inês Gonçalves";

        private string controls = "Play with the arrow keys";

        public void Options()
        {
            bool end = false;

            do
            {
                Console.Clear();
                MainMenu();
                int option;
                int.TryParse(Console.ReadLine(), out option);
                Console.Clear();

                switch (option)
                {
                    case 1:
                    // add game

                    case 2:
                        Console.Clear();
                        Controls();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Credits();
                        Console.ReadKey();
                        break;
                    case 4:
                        end = true;
                        break;
                    default:
                        break;
                }
            }

            while (end == false);
            Thanks();
            return;
        }

        private void MainMenu()
        {
            Console.WriteLine(title);
            Console.WriteLine("\n1. Play \n2. Controls \n3. Credits \n4.Quit!");
        }
        private void Controls()
        {
            Console.WriteLine(controls);
        }
        private void Credits()
        {
            Console.WriteLine("This game was made by: " + names);
        }
        private void Thanks()
        {
            Console.WriteLine("\nHope you had fun! Thanks for playing! :)");
        }
    }
}
