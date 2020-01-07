using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    /// <summary>
    /// Classe Menu onde é criada a interface do jogo
    /// </summary>
    public class Menu
    {
        // Titulo
        private string title = "Breakout";

        // Nomes autoras
        private string names = "\nDiana Nóia & Inês Gonçalves";

        // Instruções
        private string controls = "Play with the arrow keys";

        // Instância da lista dos bricks
        private List<Brick> bricks;
        // Textura do brick
        private string brickPrint = "\u2580\u2580 ";

        // Instância da bola
        private Ball ball;
        // Textura da bola
        private string ballPrint = "\u2580";
        // Posições x y da bola
        private int ballPosX;
        private int ballPosY;

        // Instância da paddle
        private Paddle paddle;
        // Textura da paddle
        private string paddlePrint =
            " \u2580\u2580\u2580\u2580\u2580\u2580\u2580 ";
        // Posiçãp da paddle
        private int paddlePos;

        /// <summary>
        /// Propriedade de pontos
        /// </summary>
        public int Points { get; set; } = 0;

        // Instância de GameManager
        private GameManager gm;

        // Instância de Breakout
        public Breakout br;

        /// <summary>
        /// Método construtor da classe Menu
        /// </summary>
        /// <param name="gm"></param>
        /// <param name="br"></param>
        public Menu(GameManager gm, Breakout br)
        {
            this.gm = gm;
            this.br = br;
            // Chama método MainMenu()
            MainMenu();
        }

        /// <summary>
        /// Método Update que corre o jogo frame a frame
        /// </summary>
        public void Update()
        {
            // Chama método MoveBall()
            ball.MoveBall();
            // Chama método MovePaddle()
            paddle.MovePaddle();
        }

        /// <summary>
        /// Método que guarda as opções
        /// </summary>
        public void Options()
        {
            // Enquanto for true
            while (true)
            {
                //  Switch que lê a tecla que o jogador pressiona e age de
                // acordo com a mesma
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

        /// <summary>
        /// Método que mostra o titulo e as opções 
        /// </summary>
        private void MainMenu()
        {
            Console.WriteLine(title);
            Console.WriteLine("\n1. Play \n2. Controls \n3. Credits \n4. Quit!\n");
            // Chama método Options()
            Options();
        }
        /// <summary>
        /// Método que mostra os controlos
        /// </summary>
        private void Controls()
        {
            Console.WriteLine(controls);
        }
        /// <summary>
        /// Método que mostra os créditos
        /// </summary>
        private void Credits()
        {
            Console.WriteLine("This game was made by: \n" + names);
        }
        /// <summary>
        /// Método que agradece ao jogador
        /// </summary>
        private void Thanks()
        {
            Console.WriteLine("Hope you had fun! Thanks for playing! :)");
            // Termina o programa
            Environment.Exit(0);
        }

        /// <summary>
        /// Método que mostra os bricks, a paddle e a bola
        /// </summary>
        public void ShowGame()
        {
            // Cria uma nova lista de bricks
            bricks = new List<Brick>();
            Console.WriteLine();
            Console.Write(" ");
            // Desenhar as linhas com os bricks
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

            // Posição inicial da paddle
            Console.SetCursorPosition(28, 30);
            paddlePos = Console.CursorLeft;

            // Cria nova paddle
            paddle = new Paddle(paddlePrint, paddlePos);

            // Imprime a paddle 
            paddle.PaddlePrint = paddlePrint;
            Console.ForegroundColor = ConsoleColor.White;
            paddle.PrintPaddle();

            // Posição inicial da bola
            Console.SetCursorPosition(31, 12);
            ballPosX = Console.CursorLeft;
            ballPosY = Console.CursorTop;

            // Cria nova bola
            ball = new Ball(ballPrint, ballPosX, ballPosY, this, paddlePos, bricks);

            // Imprime bola
            Console.ForegroundColor = ConsoleColor.Cyan;
            ball.PrintBall();

            Console.SetCursorPosition(28, 35);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Points: " + 0);
        }

        /// <summary>
        /// Método que mostra os pontos
        /// </summary>
        public void ShowPoints()
        {
            Console.SetCursorPosition(28, 35);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Points: " + (Points += 10));
        }

        /// <summary>
        /// Método chamado quando o jogador perde
        /// </summary>
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
