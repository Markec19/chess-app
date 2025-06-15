using chess_app.utility.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    class Move
    {
        public Piece MovingPiece { get; set; }
        public Field TargetField { get; set; }
        public Piece CapturedPiece { get; set; }
        //public bool IsCastling { get; set; }
        //public bool IsEnPassant { get; set; }
        public bool IsPromotion { get; set; }
        public string PromotionPieceType { get; set; }

        public Move(Piece movingPiece, Field targetField, Piece capturedPiece = null, bool isCastling = false, bool isEnPassant = false, bool isPromotion = false, string promotionPieceType = null)
        {
            MovingPiece = movingPiece;
            TargetField = targetField;
            if (targetField.OccupyingPiece != null)
            {
                CapturedPiece = targetField.OccupyingPiece;
            }
            //IsCastling = isCastling;
            //IsEnPassant = isEnPassant;
            IsPromotion = isPromotion;
            PromotionPieceType = promotionPieceType;
        }

        public void ExecuteMove()
        {
            MovingPiece.CurrentField = TargetField;
            if (CapturedPiece != null)
            {
                CapturedPiece.Eaten = true;
            }

            if (isCastlingMove())
            {
                TargetField.OccupyingPiece = MovingPiece;
                MovingPiece.CurrentField = TargetField;

                int currentXIndex = Board.XAxisToIndex[MovingPiece.CurrentField.X_axis];
                int targetXIndex = Board.XAxisToIndex[TargetField.X_axis];

                int rookXIndex = (currentXIndex + targetXIndex) / 2;
                Piece rook = new Rook();

                if (targetXIndex < currentXIndex)
                {
                    rook = Board.GetField(0, 0).OccupyingPiece;
                } else
                {
                    rook = Board.GetField(7, 0).OccupyingPiece;
                }

                rook.CurrentField.OccupyingPiece = null;
                rook.CurrentField = Board.GetField(rookXIndex, 0);
            }

            else if (IsPromotion)
            {
                Piece promotedPiece = null;
                switch (PromotionPieceType)
                {
                    case "Queen":
                        MovingPiece = new Queen(MovingPiece.Color, TargetField);
                        break;
                    case "Rook":
                        MovingPiece = new Rook(MovingPiece.Color, TargetField);
                        break;
                    case "Bishop":
                        MovingPiece = new Bishop(MovingPiece.Color, TargetField);
                        break;
                    case "Knight":
                        MovingPiece = new Knight(MovingPiece.Color, TargetField);
                        break;
                }

                //TargetField.OccupyingPiece = promotedPiece;
                //MovingPiece.Eaten = true;
            }
            else
            {
                TargetField.OccupyingPiece = MovingPiece;
                MovingPiece.CurrentField = TargetField;
                if (isEnPassantMove())
                {
                    TargetField.OccupyingPiece.Eaten = true;
                }
                MovingPiece.hasMoved = true;
            }

        }

        private bool isCastlingMove()
        {
            int currentXIndex = Board.XAxisToIndex[MovingPiece.CurrentField.X_axis];
            int targetXIndex = Board.XAxisToIndex[TargetField.X_axis];

            if (MovingPiece is King && Math.Abs(currentXIndex - targetXIndex) == 2)
            {
                return true;
            }
            return false;
        }

        private bool isEnPassantMove()
        {
            if (MovingPiece is Pawn)
            {
                int currentYIndex = Board.YAxisToIndex[MovingPiece.CurrentField.Y_axis];
                int targetYIndex = Board.YAxisToIndex[TargetField.Y_axis];

                if (targetYIndex == currentYIndex + 1 || targetYIndex == currentYIndex - 1)
                {
                    return true;
                }
            }
            return false;

        }







    }
}
