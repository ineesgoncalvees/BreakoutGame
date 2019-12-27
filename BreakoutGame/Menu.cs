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

        private readonly int height = 20, width = 60;
        private GameManager gm;

        public Menu(GameManager gm)
        {
            this.gm = gm;
            MainMenu();
        }

        public void Update()
        {
            ShowGame();
        }

        public void Options()
        {
            while(true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        return;
                    case "2":
                        Console.Clear();
                        Controls();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Credits();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Thanks();
                        break;
                    default:
                        Console.WriteLine("Enter a diferent number please");
                        Console.ReadLine();
                        Console.Clear();
                        gm.GameLoop();
                        break;
                }
            }
        }

        private void MainMenu()
        {
            Console.WriteLine(title);
            Console.WriteLine("\n1. Play \n2. Controls \n3. Credits \n4. Quit!\n");
            Options();
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
            Console.WriteLine("Hope you had fun! Thanks for playing! :)");
            Environment.Exit(0);
        }

        private void ShowGame()
        {
            for(int i =0; i < height; i++)
            {
                for(int j=0; j<width; j++)
                {
                    if (i == 0 || i == height - 1)
                    {
                        Console.Write("-");
                    }
                    else if (j == 0 || j == width - 1)
                    {
                        Console.Write("|");
                    }
                }
            }
        }
    }
}
