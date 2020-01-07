using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BreakoutGame
{
    /// <summary>
    /// Classe que controla a bola
    /// </summary>
    class Ball
    {
        // Boleano que indica se a bola está a mover para baixo
        public bool isDown = true;
        // Boleano que indica se a bola está a mover para a esquerda
        public bool isLeft = false;

        // Poição da paddle
        private int paddlePos;
        // Instância da lista de bricks
        private List<Brick> bricks;

        /// <summary>
        /// Propriedade da textura da bola
        /// </summary>
        private string BallPrint { get; set; }

        /// <summary>
        /// Propriedade da posição x da bola
        /// </summary>
        private int BallPosX { get; set; }
        /// <summary>
        /// Propriedade da posição y da bola
        /// </summary>
        private int BallPosY { get; set; }

        // Instância da classe menu
        private Menu m;

        /// <summary>
        /// Método construtor da classe Ball
        /// </summary>
        /// <param name="ballPrint"></param>
        /// <param name="ballPosX"></param>
        /// <param name="ballPosY"></param>
        /// <param name="m"></param>
        /// <param name="paddlePos"></param>
        /// <param name="bricks"></param>
        public Ball(string ballPrint, int ballPosX, int ballPosY, Menu m, int paddlePos, List<Brick> bricks)
        {
            BallPrint = ballPrint;
            BallPosX = ballPosX;
            BallPosY = ballPosY;
            this.m = m;
            this.paddlePos = paddlePos;
            this.bricks = bricks;
        }

        /// <summary>
        /// Método que imprime a bola
        /// </summary>
        public void PrintBall()
        {
            Console.Write(BallPrint);
        }

        /// <summary>
        /// Método que apaga a bola
        /// </summary>
        public void EraseBall()
        {
            Console.SetCursorPosition(BallPosX, BallPosY);
            Console.Write(" ");
        }

        /// <summary>
        /// Método que move a bola
        /// </summary>
        public void MoveBall()
        {
            // Verifica colisão com a paddle
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
            // quando bate na parede, a variável isLeft fica a true
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

                if (BallPosX == Console.BufferWidth - 1)
                    isLeft = true;
            }
            // Se isLeft for true e a bola ainda não saiu de jogo a bola
            // continua a descer mas muda a direçao para a esquerda
            else if (BallPosX != 0 &&
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
            // Se a bola estiver dentro dos limites do jogo e estiver a subir e
            // a mover-se para a direita e não bater no topo da consola e se
            // bater na parede ela muda de direção para a esquerda
            else if (BallPosX < Console.BufferWidth - 1 &&
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
            // Se a bola estiver dentro dos limites do jogo e estiver a subir e
            // a mover-se para a esquerda e não bater no topo da consola e se
            // bater na parede ela muda de direção para a direita
            else if (BallPosX <= Console.BufferWidth - 1 &&
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
            // Se a bola passar o limite do y da paddle, o jogador perde
            else if (BallPosY >= 33)
            {
                m.LoseGame();
            }
            // Se bater no topo da consola a bola muda de direção para baixo
            else if (BallPosY == 0)
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

        /// <summary>
        /// Método que faz a colisão da bola com os bricks e adiciona os pontos
        /// </summary>
        public void BrickCollision()
        {
            for (int i = bricks.Count - 1; i >= 0; i--)
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
