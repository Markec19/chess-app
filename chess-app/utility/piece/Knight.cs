using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    class Knight : Piece
    {

        public Knight() { }
        public Knight(string color, string name, Field currentField) : base(color, name, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            int x = Board.XAxisToIndex[CurrentField.X_axis];
            int y = Board.YAxisToIndex[CurrentField.Y_axis];

            int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
            int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

            for (int i = 0; i < 8; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8)
                {
                    var field = Board.GetField(nx, ny);
                    if (field.OccupyingPiece == null || field.OccupyingPiece.Color != this.Color)
                        Moves.Add(field);
                }
            }



            return Moves;
        }
    }
}
