using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    internal class Bishop : Piece
    {
        public Bishop(string color, Field currentField) : base(color, currentField)
        {
        }

        protected override List<Field> checkPossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
