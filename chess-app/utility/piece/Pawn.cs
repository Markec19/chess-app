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
        public Pawn(string color, Field currentField) : base(color, currentField)
        {
        }

        public override List<Field> checkPossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
