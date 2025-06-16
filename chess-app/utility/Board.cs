using chess_app.utility.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    public class Board
    {
        public static Field[,] Fields;
        public List<Piece> WhitePieces { get; }
        public List<Piece> BlackPieces { get; }

        public Board()
        {
            Fields = new Field[8, 8];
            WhitePieces = new List<Piece>();
            BlackPieces = new List<Piece>();

            //generateBoard();
            //generatePieces();
            initializeBoard();
        }

        /*        private void generateBoard()
                {
                    string[] xAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
                    string[] yAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };
                    string[] colors = { "white", "black" };
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            string color = (i + j) % 2 == 0 ? colors[0] : colors[1];
                            fields[i, j] = new Field(xAxis[i], yAxis[j], color);
                        }
                    }
                }

                private void generatePieces()
                {

                }
        */

        public static Dictionary<string, int> XAxisToIndex { get; } = new Dictionary<string, int>
    {
        { "a", 0 },
        { "b", 1 },
        { "c", 2 },
        { "d", 3 },
        { "e", 4 },
        { "f", 5 },
        { "g", 6 },
        { "h", 7 }
    };

        public static Dictionary<string, int> YAxisToIndex { get; } = new Dictionary<string, int>
    {
        { "1", 0 },
        { "2", 1 },
        { "3", 2 },
        { "4", 3 },
        { "5", 4 },
        { "6", 5 },
        { "7", 6 },
        { "8", 7 }
    };

        private void initializeBoard()
        {
            string[] xAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
            string[] yAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    string color = (x + y) % 2 == 0 ? "white" : "black";
                    //fields[x, y] = new Field(xAxis[x], yAxis[yAxis.Length - 1 - y], color);
                    Fields[x, y] = new Field(xAxis[x], yAxis[7 - y], color);

                    if (y == 1)
                    {
                        Pawn pawn = new Pawn("white", "Pawn", Fields[x, y]);
                        Fields[x, y].OccupyingPiece = pawn;
                        WhitePieces.Add(pawn);
                    }
                    else if (y == 0)
                    {
                        Piece piece = null;
                        switch (x)
                        {
                            case 0:
                            case 7:
                                piece = new Rook("white", "Rook", Fields[x, y]);
                                break;
                            case 1:
                            case 6:
                                piece = new Knight("white", "Knight", Fields[x, y]);
                                break;
                            case 2:
                            case 5:
                                piece = new Bishop("white", "Bishop", Fields[x, y]);
                                break;
                            case 3:
                                piece = new Queen("white", "Queen", Fields[x, y]);
                                break;
                            case 4:
                                piece = new King("white", "King", Fields[x, y]);
                                break;
                        }
                        if (piece != null)
                        {
                            Fields[x, y].OccupyingPiece = piece;
                            WhitePieces.Add(piece);
                        }
                    }
                    else if (y == 6)
                    {
                        Pawn pawn = new Pawn("black", "Pawn", Fields[x, y]);
                        Fields[x, y].OccupyingPiece = pawn;
                        BlackPieces.Add(pawn);
                    }
                    else if (y == 7)
                    {
                        Piece piece = null;
                        switch (x)
                        {
                            case 0:
                            case 7:
                                piece = new Rook("black", "Rook", Fields[x, y]);
                                break;
                            case 1:
                            case 6:
                                piece = new Knight("black", "Knight", Fields[x, y]);
                                break;
                            case 2:
                            case 5:
                                piece = new Bishop("black", "Bishop", Fields[x, y]);
                                break;
                            case 3:
                                piece = new Queen("black", "Queen", Fields[x, y]);
                                break;
                            case 4:
                                piece = new King("black", "King", Fields[x, y]);
                                break;
                        }
                        if (piece != null)
                        {
                            Fields[x, y].OccupyingPiece = piece;
                            BlackPieces.Add(piece);
                        }
                    }
                    else
                    {
                        Fields[x, y].OccupyingPiece = null;
                    }
                }
            }
        }

        public static Field GetField(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return null;
            }
            return Fields[x, y];
        }






    }



}
