using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class ChessBoard
    {
        public string[,] board = new string[8, 8];

        public ChessBoard()
        {

            //+  board = new string[8 , 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i <= 1 || i >= 6)
                    {
                        if (i == 0)
                        {
                            board[i, 0] = "WR "; board[i, 1] = "WK "; board[i, 2] = "WB "; board[i, 3] = "WQN";
                            board[i, 4] = "WKN"; board[i, 6] = "WB "; board[i, 5] = "WK "; board[i, 7] = "WR ";
                        }
                        if (i == 1)
                        {
                            for (int y = 0; y < 8; y++)
                                board[i, y] = "WP ";
                        }
                        if (i == 6)
                        {
                            for (int y = 0; y < 8; y++)
                                board[i, y] = "BP ";
                        }
                        if (i == 7)
                        {
                                board[i, 0] = "BR "; board[i, 1] = "BK "; board[i, 2] = "BB "; board[i, 3] = "BQN";
                                board[i, 4] = "BKN"; board[i, 6] = "BB "; board[i, 5] = "BK "; board[i, 7] = "BR ";
                        }
                    }
                    else
                    {

                        for (int y = 0; y < 8; y++)
                        {
                            board[i, y] = "   ";
                        }
                    }
                }
            }
            
               PrintBoard();
        }
        public  bool SelectedPiecePawnMove(int player, int i, int j, int x, int y)
        {
           bool SelectedPiecePawnMove = false;

            if (player == 1)
            {
                if (board[x, y] == "WP ")
                {
                    x = x + player;
                    if (i == x && j == y && board[i, j] == "   " || j == y - 1 || j == y + 1 && board[i, j] == "BK " || board[i, j] == "BR " || board[i, j] == "BB " || board[i, j] == "BQN" ||
                    board[i, j] == "BKN" || board[i, j] == "BP ")   
                    {
                        if (board[x, y] == "   ")
                        {
                            SelectedPiecePawnMove = true;
                        }
                    }
                }
            }
            else
            {
                if (board[x, y] == "BP ")
                {
                    x = x + player;
                    if (i == x && j == y && board[i, j] == "   " || j == y - 1 || j == y + 1 && board[i, j] == "WK " || board[i, j] == "WR " || board[i, j] == "WB " || board[i, j] == "WQN" ||
                    board[i, j] == "WKN" || board[i, j] == "WP ")
                    {
                        if (board[x, y] == "   ")
                        {
                            SelectedPiecePawnMove = true;
                        }
                    }
                }
            }
            return SelectedPiecePawnMove;
        }

        public bool SelectedPieceRookMove(int player, int i, int j, int x, int y)
        {
            bool SelectedPieceRookMove = false;
            string CurrentPlayer;
            if (player == 1)
            {
                CurrentPlayer = "WK ";
            }
            else
            {
                CurrentPlayer = "BK ";
            }
             if (board[x, y] == CurrentPlayer)
             {
                //check Rook Move Top To Bottom :
                if (x < i && y == j)
                {
                    SelectedPieceRookMove = true;
                    for (int a = x + 1; a < i; a++)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[a, y] == "   ")
                            {
                                SelectedPieceRookMove = true;
                            }
                            else
                            {
                                SelectedPieceRookMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Rook Move Bottom To Top :
                if (x > i && y == j)
                {
                    SelectedPieceRookMove = true;
                    for (int a = x - 1; a > i; a--)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[a, y] == "   ")
                            {
                                SelectedPieceRookMove = true;
                            }
                            else
                            {
                                SelectedPieceRookMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Rook Move Right To Left :
                if (y < j && x == i)
                {
                    SelectedPieceRookMove = true;
                    for (int a = y + 1; a < j; a++)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[x, a] == "   ")
                            {
                                SelectedPieceRookMove = true;
                            }
                            else
                            {
                                SelectedPieceRookMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Rook Move Left To Right :
                if (y > j && x == i)
                {
                    SelectedPieceRookMove = true;
                    for (int a = y - 1; a > j; a--)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[x, a] == "   ")
                            {
                                SelectedPieceRookMove = true;
                            }
                            else
                            {
                                SelectedPieceRookMove = false;
                                break;
                            }
                        }
                    }
                }
              
             }
          
            return SelectedPieceRookMove;
        }
        public bool SelectedPieceBishopMove(int player, int i, int j, int x, int y)
        {
            bool SelectedPieceRookMove = false;
            string CurrentPlayer;
            if (player == 1)
            {
                CurrentPlayer = "WB ";
            }
            else
            {
                CurrentPlayer = "BB ";
            }
            if (board[x, y] == CurrentPlayer)
            {
                //check Bishop Move Top Right To Bottom Left:
                if (x < i && y < j)
                {
                    SelectedPieceRookMove = true;
                    for (int a = x; a < i; a++)
                    {
                        if (a >= 0 && a < 7)
                        {
                            x++;
                            y++;
                            if(x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceRookMove = true;
                                }
                                else
                                {
                                    SelectedPieceRookMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                //check Bishop Move Top Left To Bottom Right:
                if (x < i && y > j)
                {
                    SelectedPieceRookMove = true;
                    for (int a = x; a < i; a++)
                    {
                        if (a > 0 && a < 7)
                        {
                            x++;
                            y--;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceRookMove = true;
                                }
                                else
                                {
                                    SelectedPieceRookMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                //check Bishop Move Bottom Right To Top Left :
                if (x > i && y < j)
                {
                    SelectedPieceRookMove = true;
                    for (int a = y; a < i; a++)
                    {
                        if (a > 0 && a < 7)
                        {
                            x--;
                            y++;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceRookMove = true;
                                }
                                else
                                {
                                    SelectedPieceRookMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                //check Bishop Move Bottom Left To Top Right :
                if (x > i && y > j)
                {
                    SelectedPieceRookMove = true;
                    for (int a = y; a < i; a++)
                    {
                        if (a >= 0 && a < 7)
                        {
                            x--;
                            y--;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceRookMove = true;
                                }
                                else
                                {
                                    SelectedPieceRookMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            return SelectedPieceRookMove;
        }
        public bool SelectedPieceKnightMove(int player, int i, int j, int x, int y)
        {
            bool SelectedPieceKnightMove = false;
            string CurrentPlayer;
            if (player == 1)
            {
                CurrentPlayer = "WK ";
            }
            else
            {
                CurrentPlayer = "BK ";
            }
            if (board[x, y] == CurrentPlayer)
            {
                //check Knight Move 2 Times Right To 1 time Bottom:
                 if (i == x - 1 && j == y + 2)
                 {
                    SelectedPieceKnightMove = true;
                 }
                 else
                 //check Knight Move 2 Times Right To 1 time Bottom:
                 if (i == x - 1 && j == y - 2)
                 {
                    SelectedPieceKnightMove = true;
                 }
                else
                //check Knight Move 2 Times Right To 1 time Top:
                if (i == x + 1 && j == y + 2)
                {
                    SelectedPieceKnightMove = true;
                }
                else
                //check Knight Move 2 Times Left To 1 time Top:
                if (i == x + 1 && j == y - 2)
                {
                    SelectedPieceKnightMove = true;
                }
                else
                 //check Knight Move 1 time Left && 2 times Bottom:
                if (i == x + 2 && j == y - 1)
                {
                    SelectedPieceKnightMove = true;
                }
                else
                //check Knight Move 1 time Right && 2 times Bottom:
                if (i == x + 2 && j == y + 1)
                {
                    SelectedPieceKnightMove = true;
                }
                else
                //check Knight Move 1 time Left && 2 times Top:
                if (i == x - 2 && j == y - 1)
                {                  
                    SelectedPieceKnightMove = true;
                }
                else
                //check Knight Move 1 time Right && 2 times Top:
                if (i == x - 2 && j == y + 1)
                {
                    SelectedPieceKnightMove = true;
                }
              
                else
                {
                    SelectedPieceKnightMove = false;
                }
            }

            return SelectedPieceKnightMove;
        }
        public bool SelectedPieceKingMove(int player, int i, int j, int x, int y)
        {
            bool SelectedPieceKingMove = false;
            string CurrentPlayer;
            if (player == 1)
            {
                CurrentPlayer = "WKN";
            }
            else
            {
                CurrentPlayer = "BKN";
            }
            if (board[x, y] == CurrentPlayer)
            {
                //check Knight Move 1 Times Right 1 time Bottom:
                if (i == x + 1 && j == y + 1)
                {
                    SelectedPieceKingMove = true;
                }
                else
                //check Knight Move 1 Times Left To 1 time Bottom:
                if (i == x + 1 && j == y - 1)
                {
                    SelectedPieceKingMove = true;
                }
                else
               //check Knight Move 1 Times Right To 1 time Top:
               if (i == x - 1 && j == y + 1)
                {
                    SelectedPieceKingMove = true;
                }
                else
               //check Knight Move 1 Times Left To 1 time Top:
               if (i == x - 1 && j == y - 1)
                {
                    SelectedPieceKingMove = true;
                }
                else
               //check Knight Move 1 time Bottom:
               if (i == x + 1 && j == y)
                {
                    SelectedPieceKingMove = true;
                }
                else
               //check Knight Move 1 time Top:
               if (i == x - 1 && j == y)
                {
                    SelectedPieceKingMove = true;
                }
                else
               //check Knight Move 1 time Left:
               if (i == x && j == y - 1)
                {
                    SelectedPieceKingMove = true;
                }
                else
               //check Knight Move 1 time Right:
               if (i == x && j == y + 1)
                {
                    SelectedPieceKingMove = true;
                }

                else
                {
                    SelectedPieceKingMove = false;
                }
            }
            return SelectedPieceKingMove;
        }
        public bool SelectedPieceQueenMove(int player, int i, int j, int x, int y)
        {
            bool SelectedPieceQueenMove = false;
            string CurrentPlayer;
            if (player == 1)
            {
                CurrentPlayer = "WQN";
            }
            else
            {
                CurrentPlayer = "BQN";
            }
            if (board[x, y] == CurrentPlayer)
            {
                //check Rook Move Top To Bottom :
                if (x < i && y == j)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = x + 1; a < i; a++)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[a, y] == "   ")
                            {
                                SelectedPieceQueenMove = true;
                            }
                            else
                            {
                                SelectedPieceQueenMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Rook Move Bottom To Top :
                if (x > i && y == j)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = x - 1; a > i; a--)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[a, y] == "   ")
                            {
                                SelectedPieceQueenMove = true;
                            }
                            else
                            {
                                SelectedPieceQueenMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Rook Move Right To Left :
                if (y < j && x == i)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = y + 1; a < j; a++)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[x, a] == "   ")
                            {
                                SelectedPieceQueenMove = true;
                            }
                            else
                            {
                                SelectedPieceQueenMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Rook Move Left To Right :
                if (y > j && x == i)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = y - 1; a > j; a--)
                    {
                        if (a >= 0 && a <= 7)
                        {
                            if (board[x, a] == "   ")
                            {
                                SelectedPieceQueenMove = true;
                            }
                            else
                            {
                                SelectedPieceQueenMove = false;
                                break;
                            }
                        }
                    }
                }
                //check Bishop Move Top Right To Bottom Left:
                if (x < i && y < j)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = x; a < i; a++)
                    {
                        if (a >= 0 && a < 7)
                        {
                            x++;
                            y++;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceQueenMove = true;
                                }
                                else
                                {
                                    SelectedPieceQueenMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                //check Bishop Move Top Left To Bottom Right:
                if (x < i && y > j)
                {
                    SelectedPieceQueenMove  = true;
                    for (int a = x; a < i; a++)
                    {
                        if (a > 0 && a < 7)
                        {
                            x++;
                            y--;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceQueenMove = true;
                                }
                                else
                                {
                                    SelectedPieceQueenMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                //check Bishop Move Bottom Right To Top Left :
                if (x > i && y < j)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = y; a < i; a++)
                    {
                        if (a > 0 && a < 7)
                        {
                            x--;
                            y++;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceQueenMove = true;
                                }
                                else
                                {
                                    SelectedPieceQueenMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                //check Bishop Move Bottom Left To Top Right :
                if (x > i && y > j)
                {
                    SelectedPieceQueenMove = true;
                    for (int a = y; a < i; a++)
                    {
                        if (a >= 0 && a < 7)
                        {
                            x--;
                            y--;
                            if (x != i && y != j)
                            {
                                if (board[x, y] == "   ")
                                {
                                    SelectedPieceQueenMove = true;
                                }
                                else
                                {
                                    SelectedPieceQueenMove = false;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            return SelectedPieceQueenMove;
        }
        public bool MovePlate(string CurrentPlayer , int x , int y)
        {
            bool MovePlate = false;
            if (CurrentPlayer == "Player White")
            {
               
                if (board[x, y] == "WK " || board[x, y] == "WR " || board[x, y] == "WB " || board[x, y] == "WQN" || board[x, y] == "WKN" ||board[x, y] == "WP " +
                    "")
                {
                    MovePlate = true;
                }
                else
                {
                    MovePlate = false;
                }
            }
            else
            {

                if (board[x, y] == "BK " || board[x, y] == "BR " || board[x, y] == "BB " || board[x, y] == "BQN" || board[x, y] == "BKN" || board[x, y] == "BP " +
                    "")
                {
                    MovePlate = true;
                }
                else
                {
                    MovePlate = false;
                }
            }
            return MovePlate;
        }
        public void PrintBoard()
        {
            Console.WriteLine("\n                  PLAYER WHITE\n");

          Console.WriteLine("      " + 0 + "     " + 1 + "     " + 2 + "     " + 3 + "     " + 4 + "     " + 5 + "     " + 6 + "     " + 7);
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + "_");
                if (i <= 1 || i >= 6)
                {
                    if (i == 0)
                    {
                        Console.Write(" | "); Console.Write(board[i, 0]); Console.Write(" | ");
                        Console.Write(board[i, 1]); Console.Write(" | "); Console.Write(board[i, 2]);
                        Console.Write(" | "); Console.Write(board[i, 3]); Console.Write(" | ");
                        Console.Write(board[i, 4]); Console.Write(" | "); Console.Write(board[i, 5]);
                        Console.Write(" | "); Console.Write(board[i, 6]); Console.Write(" | ");
                        Console.Write(board[i, 7]); Console.Write(" | ");
                    }
                    if (i == 1)
                    {
                        Console.Write(" | ");
                        for (int y = 0; y < 8; y++)
                        {
                            Console.Write(board[i, y]);
                            Console.Write(" | ");
                        }
                    }
                    if (i == 7)
                    {

                        Console.Write(" | "); Console.Write(board[i, 0]); Console.Write(" | ");
                        Console.Write(board[i, 1]); Console.Write(" | "); Console.Write(board[i, 2]);
                        Console.Write(" | "); Console.Write(board[i, 3]); Console.Write(" | ");
                        Console.Write(board[i, 4]); Console.Write(" | "); Console.Write(board[i, 5]);
                        Console.Write(" | "); Console.Write(board[i, 6]); Console.Write(" | ");
                        Console.Write(board[i, 7]); Console.Write(" | ");
                    }
                    if (i == 6)
                    {
                        Console.Write(" | ");
                        for (int y = 0; y < 8; y++)
                        {
                            Console.Write(board[i, y]);
                            Console.Write(" | ");
                        }
                    }
                }
                else
                {
                    Console.Write(" | ");
                    for (int y = 0; y < 8; y++)
                    {
                        Console.Write(board[i, y]);
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine("\n------------------------------------------------------");
            }
            Console.WriteLine("\n                 PLAYER BLACK\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string CurrentPlayer;
            bool TerminateDes = false;
            bool gameOver = false;
            int Player = 1;
            int x;
            int y;
            ChessBoard cb = new ChessBoard();
            while (gameOver == false)
            {
                TerminateDes = false;
                while (TerminateDes == false)
                {
                    if (Player == 1)
                    {
                        CurrentPlayer = "Player White";
                    }
                    else
                    {
                        CurrentPlayer = "Player Black";
                    }
                        Console.WriteLine(CurrentPlayer + " Enter Position of Desired piece");
                        Console.WriteLine("Enter Position of X :");
                        Console.WriteLine("Enter Position to selected to move piece:");
                    x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Position of Y :");
                        y = Convert.ToInt32(Console.ReadLine());
                    if (x <= 7 && y <= 7 )
                    {
                        Console.WriteLine(cb.board[x, y]);
                        if (cb.board[x, y] == "   ")
                        {
                            TerminateDes = false;
                            Console.WriteLine(CurrentPlayer + " ReEnter Position Because Null Piece at this position");
                        }
                        else
                        {
                            if (cb.MovePlate(CurrentPlayer, x, y))
                            {
                                    Console.WriteLine(CurrentPlayer + " Enter Position To Selected Piece To Move :");
                                    Console.WriteLine("Enter Position of    i :");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter Position of j :");
                                    int j = Convert.ToInt32(Console.ReadLine());
                                    if (x <= 7 && y <= 7)
                                    {
                                        if (cb.SelectedPiecePawnMove(Player, i, j, x, y))
                                        {
                                            if (Player == 1)
                                            {
                                            if(cb.board[i, j] == "BKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WP ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "BK " || cb.board[i, j] == "BR " || cb.board[i, j] == "BB " || cb.board[i, j] == "BQN"  || cb.board[i, j] == "BP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WP ";
                                            }

                                            cb.PrintBoard();
                                            Player = Player * -1;
                                            TerminateDes = true;

                                        }
                                            else
                                            {
                                            if (cb.board[i, j] == "WKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BP ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                            }
                                            if (cb.board[i, j] == "WK " || cb.board[i, j] == "WR " || cb.board[i, j] == "WB " || cb.board[i, j] == "WQN"  || cb.board[i, j] == "WP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BP ";
                                            }
                                            cb.PrintBoard();
                                            Player = Player * -1;
                                            TerminateDes = true;

                                            }
                                          
                                        }       
                                    if (cb.SelectedPieceRookMove(Player, i, j, x, y))
                                    {
                                        if (Player == 1)
                                        {
                                            if (cb.board[i, j] == "BKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WK ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "BK " || cb.board[i, j] == "BR " || cb.board[i, j] == "BB " || cb.board[i, j] == "BQN" || cb.board[i, j] == "BP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WK ";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            { 
                                                TerminateDes = false;
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                            }

                                        }
                                        else
                                        {
                                            if (cb.board[i, j] == "WKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BK ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "WK " || cb.board[i, j] == "WR " || cb.board[i, j] == "WB " || cb.board[i, j] == "WQN" || cb.board[i, j] == "WP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BK ";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                                TerminateDes = false;
                                            }
                                        }
                                       
                                    }
                                    if (cb.SelectedPieceBishopMove(Player, i, j, x, y))
                                    {
                                        if (Player == 1)
                                        {
                                            if (cb.board[i, j] == "BKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WB ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "BK " || cb.board[i, j] == "BR " || cb.board[i, j] == "BB " || cb.board[i, j] == "BQN" || cb.board[i, j] == "BP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WB ";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                TerminateDes = false;
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                            }

                                        }
                                        else
                                        {
                                            if (cb.board[i, j] == "WKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WB ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "WK " || cb.board[i, j] == "WR " || cb.board[i, j] == "WB " || cb.board[i, j] == "WQN" || cb.board[i, j] == "WKN" || cb.board[i, j] == "WP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BB ";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                                TerminateDes = false;
                                            }
                                        }

                                    }
                                    if (cb.SelectedPieceKnightMove(Player, i, j, x, y))
                                    {
                                        if (Player == 1)
                                        {
                                            if (cb.board[i, j] == "BKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WK ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "BK " || cb.board[i, j] == "BR " || cb.board[i, j] == "BB " || cb.board[i, j] == "BQN" || cb.board[i, j] == "BP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WK ";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                TerminateDes = false;
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                            }

                                        }
                                        else
                                        {
                                            if (cb.board[i, j] == "WKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BK ";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "WK " || cb.board[i, j] == "WR " || cb.board[i, j] == "WB " || cb.board[i, j] == "WQN" || cb.board[i, j] == "WP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BK ";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                                TerminateDes = false;
                                            }
                                        }

                                    }
                                    if (cb.SelectedPieceKingMove(Player, i, j, x, y))
                                    {
                                        if (Player == 1)
                                        {
                                            if (cb.board[i, j] == "BKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WKN";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "BK " || cb.board[i, j] == "BR " || cb.board[i, j] == "BB " || cb.board[i, j] == "BQN " || cb.board[i, j] == "BP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WKN";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                TerminateDes = false;
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                            }

                                        }
                                        else
                                        {
                                            if (cb.board[i, j] == "WKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BKN";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "WK " || cb.board[i, j] == "WR " || cb.board[i, j] == "WB " || cb.board[i, j] == "WQN" || cb.board[i, j] == "WP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BKN";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                                TerminateDes = false;
                                            }
                                        }

                                    }
                                    if (cb.SelectedPieceQueenMove(Player, i, j, x, y))
                                    {
                                        if (Player == 1)
                                        {
                                            if (cb.board[i, j] == "BKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WQN";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "BK " || cb.board[i, j] == "BR " || cb.board[i, j] == "BB " || cb.board[i, j] == "BQN" || cb.board[i, j] == "BP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "WQN";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                TerminateDes = false;
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                            }

                                        }
                                        else
                                        {
                                            if (cb.board[i, j] == "WKN")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BQN";
                                                Console.WriteLine(CurrentPlayer + " Won");
                                                gameOver = true;
                                            }
                                            if (cb.board[i, j] == "WK " || cb.board[i, j] == "WR " || cb.board[i, j] == "WB " || cb.board[i, j] == "WQN" || cb.board[i, j] == "WP " || cb.board[i, j] == "   ")
                                            {
                                                cb.board[x, y] = "   ";
                                                cb.board[i, j] = "BQN";
                                                cb.PrintBoard();
                                                Player = Player * -1;
                                                TerminateDes = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine(CurrentPlayer + " ReEnter Position Because another Player Piece at this position");
                                                TerminateDes = false;
                                            }
                                        }

                                    }

                                }
                                    else
                                    {

                                      Console.WriteLine(CurrentPlayer + " Renter Position To Selected Piece To Move :");
                                        TerminateDes = false;
                                    }

                                
                               
                            }
                            else
                            {
                                TerminateDes = false;
                                Console.WriteLine(CurrentPlayer + " Renter Position To Selected Piece To Move :");
                            }

                        }
                    }
                    else
                    {
                        TerminateDes = false;
                        Console.WriteLine(CurrentPlayer + " ReEnter Position Because OUT OF BOUNDS Piece at this position");
                    }
                }
            }
        }
    }
}

