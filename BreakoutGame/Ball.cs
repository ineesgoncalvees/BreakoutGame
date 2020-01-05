﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BreakoutGame
{
    class Ball
    {
        private string BallPrint { get; set; }

        public int BallPosX { get; set; }
        public int BallPosY { get; set; }

        public Ball(string ballPrint, int ballPosX, int ballPosY)
        {
            BallPrint = ballPrint;
            BallPosX = ballPosX;
            BallPosY = ballPosY;
        }

        public void PrintBall()
        {
            Console.Write(BallPrint);
        }

        public void EraseBall()
        {
            Console.Write(" ");
        }

        public void MoveBall()
        {
            if (Console.CursorTop != Console.BufferWidth &&
                Console.CursorLeft != Console.BufferHeight)
            {
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.SetCursorPosition(BallPosX++, BallPosY++);
                PrintBall();
            }
        }
    }
}