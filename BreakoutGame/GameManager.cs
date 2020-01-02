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
            Console.SetWindowSize(60, 40);
            // Sets the buffer size of the console
            Console.SetBufferSize(60, 40);

            m = new Menu(this);
            br = new Breakout();
        }

        public void GameLoop()
        {
            Start();
            //while (!br.GameOver)
            {
                m.Update();
            }
        }
    }
}
