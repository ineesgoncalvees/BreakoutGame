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
            paddlePos = Console.CursorLeft;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        int l = Console.CursorLeft + 7;
                        if (paddlePos < 50)
                        {
                            Console.SetCursorPosition(l, 30);
                            paddlePos = Console.CursorLeft;
                        }

                        break;

                    case ConsoleKey.LeftArrow:
                        int r = Console.CursorLeft - 7;
                        if (paddlePos > 0)
                        {
                            Console.SetCursorPosition(r, 30);
                            paddlePos = Console.CursorLeft;
                        }
                        break;
                }
            }
        }
    }
}
