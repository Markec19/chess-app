using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    class Queen : Piece
    {

        public Queen()
        {
        }
        public Queen(string color, string name, Field currentField) : base(color, name, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            int x = Board.XAxisToIndex[CurrentField.X_axis];
            int y = Board.YAxisToIndex[CurrentField.Y_axis];

            for (int dx = 0; dx < 8; dx++)
            {
                if (dx + x < 7 || dx + x > 0)
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
                    }
                    else if (Board.GetField(x, dy).OccupyingPiece.Color != Color)
                    {
                        Moves.Add(Board.GetField(x, y));
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            int[] zx = { 1, 1, -1, -1 };
            int[] zy = { 1, -1, 1, -1 };

            for (int dir = 0; dir < 4; dir++)
            {
                int nx = x + zx[dir];
                int ny = y + zy[dir];
                while (nx >= 0 && nx < 8 && ny >= 0 && ny < 8)
                {
                    if (Board.GetField(nx, ny).OccupyingPiece == null)
                    {
                        Moves.Add(Board.GetField(nx, ny));
                    }
                    else
                    {
                        if (Board.GetField(nx, ny).OccupyingPiece.Color != this.Color)
                            Moves.Add(Board.GetField(nx, ny));
                        break;
                    }
                    nx += zx[dir];
                    ny += zy[dir];
                }
            }


            return Moves;
        }
    }
}
