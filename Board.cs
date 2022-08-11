using System;

namespace CampoMinado_Console_CSharp
{
    class Board
    {
        private int[,]  board;
        private bool[,] boardRevel;
        private int     size;
        
        public Board(int n =  3)
        {
            Size   = n;
            board  = new int[Size,Size];
            boardRevel = new bool[Size,Size];
            
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    board[i,j] = 0;
                    boardRevel[i,j] = false;
                }
            }
        }
        
        public bool Inside(int i, int j)
        {
            //Retorna TRUE se a coordenada estiver dentro do board;
            if(i < 0 || i >= Size || j < 0 || j >= Size) return false;
            
            return true;
        }
        
        public void InsertIn(int i, int j)
        {
            if(Inside(i,j))
            {
                board[i,j] = 1;
                Console.WriteLine("Inserido em: i = " +i+" | j = "+j);
            }
            else
            {
                Console.WriteLine("ERRO! Posição: i = " +i+" | j = "+j+ " inválida.");
            }
        }
        
        public int CountAdjacency(int i, int j)
        {
            int count = 0;
            
            for(int jAux = j-1; jAux < j+2; jAux++)
            {
                if(Inside(i-1, jAux))
                {
                    count += board[i-1, jAux];
                }
                
                if(Inside(i+1, jAux))
                {
                    count += board[i+1, jAux];
                }
            }
            
            if(Inside(i, j-1)) count += board[i, j-1];
            if(Inside(i, j+1)) count += board[i, j+1];
            
            return count;
        }
        
        public void Select(int i, int j)
        {
            if(Inside(i, j))
            {
                boardRevel[i,j] = true;
            }
        }
        
        public void Show()
        {
            Console.Write("  ");
            for(int i = 0; i < Size; i++)
            {
                Console.Write("  "+(i+1)+"  ");    
            }
            
            Console.WriteLine("");
            
            for(int i = 0; i < Size; i++)
            {
                Console.Write((i+1)+" ");
                for(int j = 0; j < Size; j++)
                {
                    Console.Write("[ ");
                    
                    if(boardRevel[i,j])
                    {
                        Console.Write(CountAdjacency(i,j));
                    }
                    else
                    {
                        Console.Write("-");    
                    }
                    
                    Console.Write(" ]");
                }
                Console.WriteLine("");
            }
        }
        
        public void ShowAllBombs()
        {
            Console.Write("  ");
            for(int i = 0; i < Size; i++)
            {
                Console.Write("  "+(i+1)+"  ");    
            }
            
            Console.WriteLine("");
            
            for(int i = 0; i < Size; i++)
            {
                Console.Write((i+1)+" ");
                for(int j = 0; j < Size; j++)
                {
                    Console.Write("[ ");
                    
                    if(board[i,j] == 1)
                    {
                        Console.Write("B");
                    }
                    else
                    {
                        Console.Write(" ");    
                    }
                    
                    Console.Write(" ]");
                }
                Console.WriteLine("");
            } 
        }
        
        public int ValueIn(int i, int j)
        {
            return this.board[i,j];
        }
        
        public int ValueInSelected(int i, int j)
        {
            if(boardRevel[i,j]) return 1;
            return 0;
        }
        
        public int Size
        {
            get{return this.size;}
            set{this.size = value;}
        }
    }
}