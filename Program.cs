using System;

namespace CampoMinado_Console_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Game  game  = new Game(board);
            game.ResetBoard();
            game.Show();
        }
    }
}
