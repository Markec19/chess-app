using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    internal abstract class Piece
    {
        protected string color;
        protected Field currentField {  get; set; }
        protected List<Field> moves;
        protected bool eaten {  get; set; }

        public Piece(string color, Field currentField) 
        {
            this.color = color;
            this.currentField = currentField;
            moves = checkPossibleMoves();
        }

        protected abstract List<Field> checkPossibleMoves();


    }
}
