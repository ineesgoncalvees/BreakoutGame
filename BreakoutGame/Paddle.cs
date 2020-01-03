using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace BreakoutGame
{
    class Paddle
    {
        public string PaddlePrint { get; set; }

        public int paddlePos;

        public Paddle(string paddlePrint, int paddlePos)
        {
            PaddlePrint = paddlePrint;
            this.paddlePos = paddlePos;
        }

        public void PrintInfo()
        {
            Console.WriteLine(PaddlePrint);
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
                        int l = paddlePos + 7;
                        if (paddlePos < 43)
                        {
                            Console.SetCursorPosition(l, 30);
                            paddlePos = Console.CursorLeft;
                            PrintInfo();

                        }

                        break;

                    case ConsoleKey.LeftArrow:
                        int r = paddlePos - 7;
                        if (paddlePos > 0)
                        {
                            Console.SetCursorPosition(r, 30);
                            paddlePos = Console.CursorLeft;
                            PrintInfo();

                        }
                        break;
                }
            }
        }
    }
}
