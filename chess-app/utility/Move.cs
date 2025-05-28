using chess_app.utility.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    internal class Move
    {
        public Field From { get; set; }
        public Field To { get; set; }
        public Piece? CapturedPiece { get; set; }
        public Piece MovedPiece { get; set; }
        public bool IsCastling { get; set; }
        public bool IsEnPassant { get; set; }
        public Piece? PromotionPiece { get; set; }
    }
}
