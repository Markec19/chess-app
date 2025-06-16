using chess_app.utility;
using chess_app.utility.piece;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace ChessAppGUI
{
    public partial class ChessForm : Form
    {
        private Board board;
        private Button[,] buttons = new Button[8, 8];
        private Piece selectedPiece = null;

        public ChessForm()
        {
            InitializeComponent();
            board = new Board();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = Padding.Empty;
                    button.Padding = Padding.Empty;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    Field field = Board.Fields[col, row];
                    button.BackColor = field.Color == "white" ? Color.White : Color.LightGray;

                    if (field.OccupyingPiece != null)
                    {
                        button.Text = GetPieceSymbol(field.OccupyingPiece);
                    }

                    button.Click += Square_Click;

                    tableLayoutPanel1.Controls.Add(button, col, row);
                    buttons[col, row] = button;
                }
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            /*Button clickedButton = (Button)sender;
            
            TableLayoutPanelCellPosition position = tableLayoutPanel1.GetCellPosition(clickedButton);
            int column = position.Column;
            int row = position.Row;

            Field clickedField = Board.Fields[column, row];

            MessageBox.Show($"Clicked on {clickedField.X_axis}{clickedField.Y_axis}");*/


            Button clickedButton = (Button)sender;

            TableLayoutPanelCellPosition position = tableLayoutPanel1.GetCellPosition(clickedButton);
            int column = position.Column;
            int row = position.Row;

            Field clickedField = Board.Fields[column, row];

            if (selectedPiece == null)
            {
                // No piece selected, check if the clicked square has a piece
                if (clickedField.OccupyingPiece != null)
                {
                    selectedPiece = clickedField.OccupyingPiece;
                    clickedButton.BackColor = Color.Yellow; // Highlight the selected square
                }
            }
            else
            {
                // A piece is selected, check if the clicked square is a valid move
                List<Field> validMoves = GetValidMoves(selectedPiece);
                if (validMoves.Contains(clickedField))
                {
                    // Move the piece
                    MovePiece(selectedPiece, clickedField);
                    ClearSelection();
                }
                else
                {
                    // Invalid move, clear selection
                    ClearSelection();
                    MessageBox.Show("Invalid move!");
                }
            }
        }

        private string GetPieceSymbol(Piece piece)
        {
            //return "figurica";
            switch (piece.Name)
            {
                case "Pawn": return "P";
                case "Rook": return "R";
                case "Knight": return "Kn";
                case "Bishop": return "B";
                case "Queen": return "Q";
                case "King": return "K";
                default: return "";
            }
        }

        private void MovePiece(Piece piece, Field targetField)
        {
            // Get the original field
            Field originalField = piece.CurrentField;

            // Update the board state
            originalField.OccupyingPiece = null;
            targetField.OccupyingPiece = piece;
            piece.CurrentField = targetField;

            // Update the GUI
            UpdateBoardUI();
        }

        private void ClearSelection()
        {
            if (selectedPiece != null)
            {
                Field originalField = selectedPiece.CurrentField;
                buttons[Board.XAxisToIndex[originalField.X_axis], Board.YAxisToIndex[originalField.Y_axis]].BackColor = originalField.Color == "white" ? Color.White : Color.LightGray;
                selectedPiece = null;
            }
        }

        private List<Field> GetValidMoves(Piece piece)
        {
            // This is a placeholder, replace with your actual move generation logic
            return piece.checkPossibleMoves();
        }

        private void UpdateBoardUI()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Field field = Board.Fields[col, row];
                    Button button = buttons[col, row];

                    if (field.OccupyingPiece != null)
                    {
                        button.Text = GetPieceSymbol(field.OccupyingPiece);
                    }
                    else
                    {
                        button.Text = "";
                    }
                }
            }
        }




    }
}
