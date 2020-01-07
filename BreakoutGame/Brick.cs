using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutGame
{
    /// <summary>
    /// Classe que contém os dados do brick
    /// </summary>
    class Brick
    {
        /// <summary>
        /// Propriedade que guarda o valor da textura do brick
        /// </summary>
        private string BrickPrint { get; set; }
        /// <summary>
        /// Propriedade que guarda o valor da posição x do brick
        /// </summary>
        public int brickPosX { get; }
        /// <summary>
        /// Propriedade que guarda o valor da posição y do brick
        /// </summary>
        public int brickPosY { get; }

        /// <summary>
        /// Método construtor da classe Brick 
        /// </summary>
        /// <param name="brickPrint"></param>
        /// <param name="brickPosX"></param>
        /// <param name="brickPosY"></param>
        public Brick(string brickPrint, int brickPosX, int brickPosY)
        {
            BrickPrint = brickPrint;
            this.brickPosX = brickPosX;
            this.brickPosY = brickPosY;
        }

        /// <summary>
        /// Método que apaga o brick
        /// </summary>
        public void EraseBrick()
        {
            Console.SetCursorPosition(brickPosX, brickPosY);
            Console.Write("  ");
        }
    }
}
