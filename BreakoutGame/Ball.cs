using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BreakoutGame
{
    class Ball
    {
        public bool isDown = true;
        public bool isLeft = false;

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
            // Quando o jogo começa a bola vai para baixo e para a direita,
            // quando bate na parede a variavel isLeft fica a true
            if(BallPosX < Console.BufferWidth - 1 && BallPosY < Console.BufferHeight - 1 && isDown && !isLeft)
            {
                EraseBall();
                BallPosX++; 
                BallPosY++;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;
                if(BallPosX == Console.BufferWidth - 1)
                    isLeft = true;
            }
            // Se isLeft ficar a true e a bola ainda não saiu de jogo
            // a bola continua a descer mas muda a direçao para a esquerda
            else if(BallPosX != 0 && BallPosX != 0 && isLeft && BallPosY <= 33 && isDown)
            {
                EraseBall();
                BallPosX--;
                BallPosY++;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;
                if (BallPosX == 0)
                    isLeft = false;
            }
            // Se isLeft estiver a false a bola anda para a direita
            else if(isDown && !isLeft && BallPosY <= 33)
            {
                EraseBall();
                BallPosX++;
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
