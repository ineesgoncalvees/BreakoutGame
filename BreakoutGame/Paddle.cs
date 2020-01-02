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

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        paddlePos += 7;
                        break;

                    case ConsoleKey.LeftArrow:
                        paddlePos-= 7;
                        break;
                }
            }
        }
    }
}
