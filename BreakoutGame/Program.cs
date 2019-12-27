using System;

namespace BreakoutGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.GameLoop();
        }
    }
}
