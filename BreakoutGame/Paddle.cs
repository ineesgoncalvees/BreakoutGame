using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    /// <summary>
    /// Classe que guarda os dados da paddle
    /// </summary>
    class Paddle
    {
        /// <summary>
        /// Propriedade que guarda o valor da textura da paddle
        /// </summary>
        public string PaddlePrint { get; set; }

        // Posição da paddle
        public int paddlePos;

        /// <summary>
        /// Método construtor da classe Paddle
        /// </summary>
        /// <param name="paddlePrint"></param>
        /// <param name="paddlePos"></param>
        public Paddle(string paddlePrint, int paddlePos)
        {
            PaddlePrint = paddlePrint;
            this.paddlePos = paddlePos;
        }

        /// <summary>
        /// Método que imprime a paddle
        /// </summary>
        public void PrintPaddle()
        {
            Console.WriteLine(PaddlePrint);
        }

        /// <summary>
        /// Método que recebe input do jogador para mover a paddle
        /// </summary>
        public void MovePaddle()
        {
            ConsoleKeyInfo keyInfo;
            Console.SetCursorPosition(paddlePos, 30);
            paddlePos = Console.CursorLeft;

            // Espera por input
            while (Console.KeyAvailable)
            {
                if ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    // Verifica input e move paddle de acordo com o mesmo
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            int l = paddlePos + 1;
                            if (paddlePos < 54)
                            {
                                Console.SetCursorPosition(l, 30);
                                paddlePos = Console.CursorLeft;
                                PrintPaddle();
                            }

                            break;

                        case ConsoleKey.LeftArrow:
                            int r = paddlePos - 1;
                            if (paddlePos > 0)
                            {
                                Console.SetCursorPosition(r, 30);
                                paddlePos = Console.CursorLeft;
                                PrintPaddle();
                            }
                            break;
                    }
                }
            }
        }
    }
}
