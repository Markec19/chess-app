using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    class Rook : Piece
    {
        public Rook() 
        { 
        }
        public Rook(string color, string name, Field currentField) : base(color, name, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            int x = Board.XAxisToIndex[CurrentField.X_axis];
            int y = Board.YAxisToIndex[CurrentField.Y_axis];

            for(int dx = 0; dx < 8; dx++)
            {
                if(dx + x < 7 || dx + x > 0)
                {
                    if (Board.GetField(dx, y).OccupyingPiece == null)
                    {
                        Moves.Add(Board.GetField(dx, y));
                    }
                    else if (Board.GetField(dx, y).OccupyingPiece.Color != Color)
                    {
                        Moves.Add(Board.GetField(dx, y));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int dy = 0; dy < 8; dy++)
            {
                if (dy + y < 7 || dy + y > 0)
                {
                    if (Board.GetField(x, dy).OccupyingPiece == null)
                    {
                        Moves.Add(Board.GetField(x, dy));
                    } else if (Board.GetField(x, dy).OccupyingPiece.Color != Color)
                    {
                        Moves.Add(Board.GetField(x, y));
                        break;
                    }
                } else
                {
                    break;
                }
            }

            return Moves;
        }


    }


}
