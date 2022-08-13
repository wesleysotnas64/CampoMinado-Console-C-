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
        
        public void Show()
        {
            Menu();

            board.Show();

            SelectClick();
        }

        public void SelectClick()
        {
            int i, j;

            Console.Write("Linha : ");
            i = Convert.ToInt32(Console.ReadLine());
            Console.Write("Coluna: ");
            j = Convert.ToInt32(Console.ReadLine());

            ClickIn(i,j);
        }

        public void ClickIn(int i, int j)
        {
            i--;
            j--;
            
            board.Select(i,j);
            
            if(board.ValueIn(i,j) == 1)
            {
                EndGameOver();
            }
            else
            {
                VerifyEndGame();
            }
        }
        
        public void VerifyEndGame()
        {
            int nBombs = CountNumberBombs();
            int nSelec = CountNumberSelected();
            
            Console.WriteLine("Quantidade de bombas     : " + nBombs);
            Console.WriteLine("Quantidade selecionadas  : " + nSelec);
            Console.WriteLine("Quantidade selec p ganhar: " + ((board.Size*board.Size) - nBombs));

            if(nSelec==((board.Size*board.Size) - nBombs))
            {
                EndGameWin();
            }
            else
            {
                Show();
            }
        }

        public void EndGameWin()
        {
            Menu();
            board.Show();
            Console.WriteLine("        PARABÉNS!!!        ");
            Console.WriteLine("---------------------------");
            ResetBoard();
        }

        public void EndGameOver()
        {
            Menu();
            board.ShowAllBombs();
            Console.WriteLine("        FIM DE JOGO        ");
            Console.WriteLine("---------------------------");
            ResetBoard();
        }

        public void Menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("       CAMPO  MINADO       ");
            Console.WriteLine("---------------------------");
        }
        
        public void ResetBoard()
        {
            int qtdBombs = Convert.ToInt32(board.Size*board.Size*0.25f);
            Random numAleatorio = new Random();

            int aux = 0; 
            int i, j;
            while(true)
            {
                i = numAleatorio.Next(0,board.Size);
                j = numAleatorio.Next(0,board.Size);

                if(board.ValueIn(i,j) != 1)
                {
                    board.InsertIn(i,j);
                    aux++;
                    if(aux >= qtdBombs) break;
                }
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