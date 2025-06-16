using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility.piece
{
    public abstract class Piece
    {
        public string Color;
        public string Name { get; set; }
        public Field CurrentField {  get; set; }
        public List<Field> Moves;

        public bool hasMoved { get; set; }
        public bool Eaten {  get; set; }

        public bool Pinned { get; set; }

        public Piece() { }

        public Piece(string color, string name, Field currentField) 
        {
            this.Color = color;
            this.Name = name;
            this.CurrentField = currentField;
            Moves = new List<Field>();
            hasMoved = false;
            Eaten = false;
            Pinned = false;
        }

        public abstract List<Field> checkPossibleMoves();


    }
}
