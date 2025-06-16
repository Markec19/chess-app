using chess_app.utility.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    public class Field
    {
        public string X_axis { get; set; }
        public string Y_axis { get; set; }
        public string Color { get; set; }
        public Piece? OccupyingPiece { get; set; }

        public Field(string x_axis, string y_axis, string color, Piece occupyingPiece)
        {
            this.X_axis = x_axis;
            this.Y_axis = y_axis;
            this.Color = color;
            this.OccupyingPiece = occupyingPiece;
        }

        public Field(string x_axis, string y_axis, string color)
        {
            this.X_axis = x_axis;
            this.Y_axis = y_axis;
            this.Color = color;
        }


    }
}
