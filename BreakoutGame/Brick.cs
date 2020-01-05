using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    class Brick
    {
        private string BrickPrint { get; set; }

        private bool isVisible;
        private bool isHit;

        private int points;

        public Brick(string brickPrint, int points)
        {
            BrickPrint = brickPrint;
            this.points = points;
            this.isVisible = true;
            this.isHit = false;
        }
    }
}
