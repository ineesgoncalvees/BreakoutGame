using System;

namespace BreakoutGame
{
    /// <summary>
    /// Classe program que inicia o jogo
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método que inicia o jogo
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Instância
            GameManager gm = new GameManager();
            // Chama método GameLoop
            gm.GameLoop();
        }
    }
}
