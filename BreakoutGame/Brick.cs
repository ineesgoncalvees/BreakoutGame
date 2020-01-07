using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    class Brick
    {
        private string BrickPrint { get; set; }
        public int brickPosX { get; }
        public int brickPosY { get; }

        public Brick(string brickPrint, int brickPosX, int brickPosY)
        {
            BrickPrint = brickPrint;
            this.brickPosX = brickPosX;
            this.brickPosY = brickPosY;
        }

        public void EraseBrick()
        {
            Console.SetCursorPosition(brickPosX, brickPosY);
            Console.Write("  ");
        }
    }
}
