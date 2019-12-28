using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    public class Menu
    {
        private string title = "Breakout";

        private string names = "Diana Nóia & Inês Gonçalves";

        private string controls = "Play with the arrow keys";

        private List<Brick> bricks;
        private string brickPrint = "\u2580\u2580 ";

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
            bricks = new List<Brick>();

            for(int row = 0; row < 2; row++)
            {
                for(int col1 = 0; col1 < 20; col1++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(brickPrint);
                }

                Console.WriteLine();

                for (int col2 = 0; col2 < 20; col2++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(brickPrint);
                }

                Console.WriteLine();

                for (int col3 = 0; col3 < 20; col3++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{brickPrint}");
                }

                Console.WriteLine();

                for (int col3 = 0; col3 < 20; col3++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{brickPrint}");
                }

                Console.WriteLine();

                for (int col3 = 0; col3 < 20; col3++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"{brickPrint}");
                }

                Console.WriteLine();
            }

        }
    }
}
