using chess_app.utility.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    internal class Field
    {
        private string x_axis { get; set; }
        private string y_axis { get; set; }
        private string color { get; set; }
        private Piece? occupyingPiece { get; set; }

        public Field(string x_axis, string y_axis, string color, Piece occupyingPiece)
        {
            this.x_axis = x_axis;
            this.y_axis = y_axis;
            this.color = color;
            this.occupyingPiece = occupyingPiece;
        }


    }
}
