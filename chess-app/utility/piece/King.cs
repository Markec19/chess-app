using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    class King : Piece
    {

        public King()
        {
        }
        public King(string color, string name, Field currentField) : base(color, name, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            int x = Board.XAxisToIndex[CurrentField.X_axis];
            int y = Board.YAxisToIndex[CurrentField.Y_axis];

            checkCastling();

            for (int dx = -1; dx <= 1; dx++)            
                for (int dy = -1; dy <= 1; dy++)               
                    if ((dx != 0 || dy != 0) && (x + dx > 0 || x + dx < 7) && (y + dy > 0 || y + dy < 7) 
                        && (Board.GetField(x + dx, y + dy).OccupyingPiece == null 
                        || Board.GetField(x + dx, y + dy).OccupyingPiece.Color != Color))
                        Moves.Add(Board.GetField(x + dx, y + dy));
                            
            return Moves;
        }

        private void checkCastling()
        {
            var piece1 = Board.GetField(0, 0).OccupyingPiece;
            var piece2 = Board.GetField(0, 7).OccupyingPiece;
            var piece3 = Board.GetField(7, 0).OccupyingPiece;
            var piece4 = Board.GetField(7, 7).OccupyingPiece;


            if (hasMoved == false && Color == "White")
            {
                if (piece1.hasMoved == false)
                    Moves.Add(Board.GetField(0, 2));
                else if (piece2.hasMoved == false)
                    Moves.Add(Board.GetField(0, 6));
            }

            if (hasMoved == false && Color == "Black")
            {
                if (piece3.hasMoved == false)
                    Moves.Add(Board.GetField(7, 2));
                else if (piece4.hasMoved == false)
                    Moves.Add(Board.GetField(7, 6));
            }
        }

    }
}
