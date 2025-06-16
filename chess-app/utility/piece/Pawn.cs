using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    class Pawn : Piece
    {

        public Pawn() { }
        public Pawn(string color, string name, Field currentField) : base(color, name, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            int x = Board.XAxisToIndex[CurrentField.X_axis];
            int y = Board.YAxisToIndex[CurrentField.Y_axis];

            if (x + 1 < 8 && Board.GetField(x + 1, y).OccupyingPiece == null)
                Moves.Add(Board.GetField(x + 1, y));

            if(x + 1 < 8 && y + 1 < 8 
                && (Board.GetField(x + 1, y + 1).OccupyingPiece != null && 
                Board.GetField(x + 1, y + 1).OccupyingPiece.Color != Color))
            {
                Moves.Add(Board.GetField(x + 1, y + 1));
            }               

            if (!hasMoved && Board.GetField(x + 2, y).OccupyingPiece == null)
                Moves.Add(Board.GetField(x + 2, y));

            return Moves;
        }
    }
}
