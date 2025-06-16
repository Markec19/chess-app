using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    class Bishop : Piece
    {

        public Bishop()
        {
        }
        public Bishop(string color, string name, Field currentField) : base(color, name, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            int x = Board.XAxisToIndex[CurrentField.X_axis];
            int y = Board.YAxisToIndex[CurrentField.Y_axis];

            int[] dx = { 1, 1, -1, -1 };
            int[] dy = { 1, -1, 1, -1 };

            for (int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];
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
                    nx += dx[dir];
                    ny += dy[dir];
                }
            }
            return Moves;
        }
    }
}
