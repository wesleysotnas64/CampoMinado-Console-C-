using System;

namespace CampoMinado_Console_CSharp
{
    class Game
    {
        public Board board;
    
        public Game(Board b)
        {
            board = b;
        }
        
        public void ClickIn(int i, int j)
        {
            i--;
            j--;
            
            board.Select(i,j);
            
            if(board.ValueIn(i,j) == 1)
            {
                board.ShowAllBombs();
                Console.WriteLine("VOCÊ PERDEU!!!");
            }
            else
            {
                board.Show();
                VerifyEndGame();
            }
        }
        
        public void VerifyEndGame()
        {
            int nBombs = CountNumberBombs();
            int nSelec = CountNumberSelected();
            
            if(nSelec==((board.Size*board.Size) - nBombs))
            {
                Console.WriteLine("PARABÉNS!!!");
                Console.WriteLine("FIM DE JOGO");
            }
        }
        
        public int CountNumberSelected()
        {
            int count = 0;
            
            for(int i = 0; i < board.Size; i++)
            {
                for(int j = 0; j < board.Size; j++) count += board.ValueInSelected(i,j);
            }
            
            return count;
        }
        
        public int CountNumberBombs()
        {
            int count = 0;
            
            for(int i = 0; i < board.Size; i++)
            {
                for(int j = 0; j < board.Size; j++) count += board.ValueIn(i,j);
            }
            
            return count;
        }
    }
}