using chess_app.utility.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    internal class Board
    {
        private List<Field> fields;
        private List<Piece> whitePieces;
        private List<Piece> blackPieces;

        public Board()
        {
            generateBoard();
            generatePieces();
            sortPieces();
        }

        private void generateBoard()
        {
            
        }

        private void generatePieces()
        {

        }

        private void sortPieces()
        {

        }
    }
}
