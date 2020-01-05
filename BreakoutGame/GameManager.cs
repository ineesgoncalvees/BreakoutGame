using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    public class GameManager
    {
        public Menu m;
        private Breakout br;

        public void Start() 
        {
            // Sets the window size
            Console.SetWindowSize(63, 40);
            // Sets the buffer size of the console
            Console.SetBufferSize(63, 40);
            Console.CursorVisible = false;

            m = new Menu(this);
            br = new Breakout();
            br.GameOver = false;
        }

        public void GameLoop()
        {
            Start();
            while (!br.GameOver)
            {
                m.Update();
            }

            Console.Clear();
            GameLoop();
        }
    }
}
