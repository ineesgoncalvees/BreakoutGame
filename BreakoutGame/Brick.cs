using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    class Brick
    {
        private string brickPrint = "   ";
        private Vector2 brickPos;
        private ConsoleColor color;

        private bool isVisible;
        private bool isHit;

        private int points;

        public Brick(string brickPrint, Vector2 brickPos, int points, ConsoleColor color)
        {
            this.brickPrint = brickPrint;
            this.brickPos = brickPos;
            this.points = points;
            this.color = color;
            this.isVisible = true;
            this.isHit = false;
        }
    }
}
