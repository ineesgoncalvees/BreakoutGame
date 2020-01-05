using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace BreakoutGame
{
    public class GameManager
    {
        private Menu m;
        private Breakout br;
        private Paddle paddle;

        public void Start() 
        {
            // Sets the window size
            Console.SetWindowSize(63, 40);
            // Sets the buffer size of the console
            Console.SetBufferSize(63, 40);
            Console.CursorVisible = false;

            br = new Breakout();
            m = new Menu(this, br);
            br.GameOver = false;
        }

        public void GameLoop()
        {
            Start();
            while (!br.GameOver)
            {
                m.Update();
                Thread.Sleep(120);
            }

            Console.Clear();
            GameLoop();
        }
    }
}
