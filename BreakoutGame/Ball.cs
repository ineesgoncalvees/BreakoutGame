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

        private int paddlePos;
        private List<Brick> bricks;

        private string BallPrint { get; set; }

        private int BallPosX { get; set; }
        private int BallPosY { get; set; }

        private Menu m;

        public Ball(string ballPrint, int ballPosX, int ballPosY, Menu m, int paddlePos, List<Brick> bricks)
        {
            BallPrint = ballPrint;
            BallPosX = ballPosX;
            BallPosY = ballPosY;
            this.m = m;
            this.paddlePos = paddlePos;
            this.bricks = bricks;
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
            if (BallPosY >= 29 &&
                BallPosY <= 31 &&
                BallPosX >= paddlePos + 1 &&
                BallPosX <= paddlePos + 8)
            {
                isDown = false;
            }

            BrickCollision();

            paddlePos = Console.CursorLeft;
            // Quando o jogo começa a bola vai para baixo e para a direita,
            // quando bate na parede a variavel isLeft fica a true
            if (BallPosX < Console.BufferWidth - 1 &&
                BallPosY < Console.BufferHeight - 1 &&
                isDown &&
                !isLeft)
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
            // Se isLeft ficar a true e a bola ainda não saiu de jogo a bola
            // continua a descer mas muda a direçao para a esquerda
            else if(BallPosX != 0 &&
                BallPosX != 0 &&
                isLeft &&
                isDown &&
                BallPosY <= 33)
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
            else if(BallPosX < Console.BufferWidth - 1 &&
                BallPosY < Console.BufferHeight - 1 &&
                !isDown &&
                !isLeft &&
                BallPosY != 0)
            {
                EraseBall();
                BallPosX++;
                BallPosY--;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;

                if (BallPosX == Console.BufferWidth - 1)
                    isLeft = true;
            }
            else if(BallPosX <= Console.BufferWidth - 1 &&
                BallPosY <= Console.BufferHeight - 1 &&
                !isDown &&
                isLeft &&
                BallPosY != 0)
            {
                EraseBall();
                BallPosX--;
                BallPosY--;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;

                if (BallPosX == 0)
                    isLeft = false;
            }
            else if (BallPosY >= 33)
            {
                m.LoseGame();
            }
            else if(BallPosY == 0)
            {
                EraseBall();
                BallPosX++;
                BallPosY++;
                Console.SetCursorPosition(BallPosX, BallPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintBall();
                Console.ForegroundColor = ConsoleColor.White;
                isDown = true;
            }
        }

        public void BrickCollision()
        {
            for(int i = bricks.Count - 1; i >= 0; i--)
            {
                if (BallPosY == bricks[i].brickPosY &&
                    BallPosX >= bricks[i].brickPosX &&
                    BallPosX <= bricks[i].brickPosX + 1)
                {
                    bricks[i].EraseBrick();
                    bricks.Remove(bricks[i]);
                    isDown = !isDown;

                    m.ShowPoints();
                }
                else if (BallPosY == bricks[i].brickPosY &&
                    BallPosX == bricks[i].brickPosX - 1)
                {
                    bricks[i].EraseBrick();
                    bricks.Remove(bricks[i]);
                    isDown = !isDown;
                    isLeft = false;

                    m.ShowPoints();
                }
                else if (BallPosY == bricks[i].brickPosY &&
                    BallPosX == bricks[i].brickPosX + 2)
                {
                    bricks[i].EraseBrick();
                    bricks.Remove(bricks[i]);
                    isDown = !isDown;
                    isLeft = true;

                    m.ShowPoints();
                }
            }
        }
    }
}
