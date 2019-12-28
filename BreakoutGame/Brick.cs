using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    class Brick
    {
        private string brickPrint = "\u2580\u2580 ";

        private bool isVisible;
        private bool isHit;

        private int points;

        public Brick(string brickPrint, int points)
        {
            this.brickPrint = brickPrint;
            this.points = points;
            this.isVisible = true;
            this.isHit = false;
        }
    }
}
