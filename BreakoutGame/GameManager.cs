using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace BreakoutGame
{
    /// <summary>
    /// Classe que corre o GameLoop e define o tamanho da consola
    /// </summary>
    public class GameManager
    {
        // Instância da classe Menu
        private Menu m;
        // Instãncia da classe Breakout
        private Breakout br;

        /// <summary>
        /// Primeiro método que é chamado quando o jogo começa e define o tamanho da 
        /// consola
        /// </summary>
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

        /// <summary>
        /// Método que corre todas as frames do jogo
        /// </summary>
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
