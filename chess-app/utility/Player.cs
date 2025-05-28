using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    internal class Player
    {
        private string color {  get; set; } 
        private bool turn {  get; set; }
        private bool isChecked { get; set; }

        public Player(string color, bool turn)
        {
            this.color = color;
            this.turn = turn;
            isChecked = false;
        }
    }
}
