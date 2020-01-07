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
            //if((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            //if(!br.GameOver)
            {
                //Console.Write(br.GameOver);
                // Call method MoveBall()
                ball.MoveBall();
                // Call method MovePaddle()
                paddle.MovePaddle();
            }
            //else
            //    br.GameOver = true;
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
                        //ShowGame();
                        //break;
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
            for (int row = 0; row < 2; row++)
            {
                for (int col1 = 0; col1 < 21; col1++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(brickPrint);
                }

                for (int col2 = 0; col2 < 21; col2++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(brickPrint);
                }

                for (int col3 = 0; col3 < 21; col3++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(brickPrint);
                }

                for (int col4 = 0; col4 < 21; col4++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(brickPrint);
                }

                for (int col5 = 0; col5 < 21; col5++)
                {
                    Brick newBrick = new Brick(brickPrint, 10);
                    bricks.Add(newBrick);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(brickPrint);
                }

            }

            // Set start position for the ball
            Console.SetCursorPosition(31, 12);
            ballPosX = Console.CursorLeft;
            ballPosY = Console.CursorTop;

            // Creats a new ball
            ball = new Ball(ballPrint, ballPosX, ballPosY, this);

            // Prints ball in cyan color
            Console.ForegroundColor = ConsoleColor.Cyan;
            ball.PrintBall();

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
        }

        public void LoseGame()
        {
            Console.Clear();
            Console.WriteLine("You lost");
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadKey();
            Console.Clear();
            br.GameOver = true;
        }
    }
}
