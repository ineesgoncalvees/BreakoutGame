using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace BreakoutGame
{
    class Paddle
    {
        public Vector2 PaddlePos { get; set; }
        public string PaddlePrint { get; set; }

        public Paddle(string paddlePrint, Vector2 paddlePos)
        {
            PaddlePrint = paddlePrint;
            PaddlePos = paddlePos;
        }
        public void PrintInfo()
        {
            Console.WriteLine(PaddlePrint);
        }
    }
}
