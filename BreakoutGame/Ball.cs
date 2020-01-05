using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BreakoutGame
{
    class Ball
    {
        private string BallPrint { get; set; }

        private int BallPosX { get; set; }
        private int BallPosY { get; set; }

        private Menu m;

        public Ball(string ballPrint, int ballPosX, int ballPosY, Menu m)
        {
            BallPrint = ballPrint;
            BallPosX = ballPosX;
            BallPosY = ballPosY;
            this.m = m;
        }

        public void PrintBall()
        {
            Console.Write(BallPrint);
        }

        public void EraseBall()
        {
            Console.SetCursorPosition(BallPosX, BallPosY);
            Console.Write(" ");
        }

        public void MoveBall()
        {
            if(BallPosX < Console.BufferWidth - 1 && BallPosY < Console.BufferHeight - 1)
            {
                EraseBall();
                BallPosX++; 
                BallPosY++;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(BallPosX == Console.BufferWidth - 1)
            {
                EraseBall();
                BallPosX--;
                BallPosY++;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (BallPosY >= 33)
            {
                m.LoseGame();
            }
        }
    }
}
