using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    public class Menu
    {
        private string title = "Breakout";

        private string names = "\nDiana Nóia & Inês Gonçalves";

        private string controls = "Play with the arrow keys";

        private List<Brick> bricks;
        private string brickPrint = "\u2580\u2580 ";

        private Ball ball;
        private string ballPrint = "\u2580";
        private int ballPosX;
        private int ballPosY;

        private Paddle paddle;
        private string paddlePrint =
            " \u2580\u2580\u2580\u2580\u2580\u2580\u2580 ";
        private int paddlePos;

        public int Points { get; set; } = 0;

        private GameManager gm;
        public Breakout br;

        public Menu(GameManager gm, Breakout br)
        {
            this.gm = gm;
            this.br = br;
            MainMenu();
        }

        public void Update()
        {
            // Call method MoveBall()
            ball.MoveBall();
            // Call method MovePaddle()
            paddle.MovePaddle();
        }

        public void Options()
        {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        ShowGame();
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
                        Console.WriteLine("Choose a different option please!");
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
            Console.WriteLine("This game was made by: \n" + names);
        }
        private void Thanks()
        {
            Console.WriteLine("Hope you had fun! Thanks for playing! :)");
            Environment.Exit(0);
        }

        public void ShowGame()
        {
            bricks = new List<Brick>();
            Console.WriteLine();
            Console.Write(" ");
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 21; col++)
                {
                    Brick newBrick = new Brick(brickPrint, col * 3, row);
                    bricks.Add(newBrick);
                    if (row == 0 || row == 5) 
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (row == 1 || row == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (row == 2 || row == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (row == 3 || row == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (row == 4 || row == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }

                    Console.SetCursorPosition(col * 3, row);

                    Console.Write(brickPrint);
                }
            }

            // Set inicial cursor position
            Console.SetCursorPosition(28, 30);
            // Sets the position of the paddle as equal to the cursor
            paddlePos = Console.CursorLeft;

            // Creats the paddle
            paddle = new Paddle(paddlePrint, paddlePos);

            // Prints the paddle in white
            paddle.PaddlePrint = paddlePrint;
            Console.ForegroundColor = ConsoleColor.White;
            paddle.PrintPaddle();

            // Set start position for the ball
            Console.SetCursorPosition(31, 12);
            ballPosX = Console.CursorLeft;
            ballPosY = Console.CursorTop;

            // Creats a new ball
            ball = new Ball(ballPrint, ballPosX, ballPosY, this, paddlePos, bricks);

            // Prints ball in cyan color
            Console.ForegroundColor = ConsoleColor.Cyan;
            ball.PrintBall();

            Console.SetCursorPosition(28, 35);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Points: " + 0);
        }

        public void ShowPoints()
        {
            Console.SetCursorPosition(28, 35);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Points: " + (Points += 10));
        }

        public void LoseGame()
        {
            Console.Clear();
            Console.WriteLine("You lost");
            Console.WriteLine("You had " + Points + " points in total!");
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadKey();
            Console.Clear();
            br.GameOver = true;
        }
    }
}
