using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    class Paddle
    {
        public string PaddlePrint { get; set; }

        public int paddlePos;

        private bool isPrinted;

        public Paddle(string paddlePrint, int paddlePos)
        {
            PaddlePrint = paddlePrint;
            this.paddlePos = paddlePos;
        }

        public void PrintPaddle()
        {
            Console.WriteLine(PaddlePrint);
        }

        public void ErasePaddle()
        {
            Console.Write("       ");
        }

        public void MovePaddle()
        {
            ConsoleKeyInfo keyInfo;
            Console.SetCursorPosition(28, 30);
            paddlePos = Console.CursorLeft;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        ErasePaddle();
                        int l = paddlePos + 7;
                        if (paddlePos < 43)
                        {
                            Console.SetCursorPosition(l, 30);
                            paddlePos = Console.CursorLeft;
                            PrintPaddle();
                        }

                        break;

                    case ConsoleKey.LeftArrow:
                        int r = paddlePos - 7;
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
