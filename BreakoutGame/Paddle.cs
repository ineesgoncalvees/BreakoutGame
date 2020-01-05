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

        public void Update()
        {
            MovePaddle();
        }

        public void PrintPaddle()
        {
            Console.WriteLine(PaddlePrint);
        }

        public void MovePaddle()
        {
            ConsoleKeyInfo keyInfo;
            Console.SetCursorPosition(paddlePos, 30);
            paddlePos = Console.CursorLeft;

            while (Console.KeyAvailable)
            {
                if ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
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
