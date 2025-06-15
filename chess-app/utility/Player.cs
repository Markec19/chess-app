using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    class Player
    {
        public string Color {  get; set; }
        public bool Turn {  get; set; }
        //public bool IsChecked { get; set; }

        public Player(string color, bool turn)
        {
            this.Color = color;
            this.Turn = turn;
            //IsChecked = false;
        }
    }
}
