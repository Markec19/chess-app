using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_app.utility
{
    class ChessGame
    {
        public Player WhitePlayer {  get; set; }
        public Player BlackPlayer { get; set; }
        //public Player CurrentPlayer { get; set; }

        public Board GameBoard {  get; set; }
        public List<Move> Moves { get; set; }
        public bool IsGameOver {  get; set; }

        public ChessGame()
        {
            WhitePlayer = new Player("White", true);
            BlackPlayer = new Player("Black", false);
            //CurrentPlayer = WhitePlayer;
            GameBoard = new Board();
            Moves = new List<Move>();
            IsGameOver = false;

            //StartGame();
        }

        public void StartGame()
        {
            while(!IsGameOver)
            {
                
            }
        }

    }
}
