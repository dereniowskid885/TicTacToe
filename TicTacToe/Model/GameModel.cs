using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TicTacToe;

namespace TicTacToe.Model
{
    class GameModel
    {
        // tablica z polami gry
        public string[] game_fields = new string[9] { " ", " ", " ", " ", " ", " ", " ", " ", " " };

        // tablica z wartosciami isEnabled przyciskow na planszy
        public bool[] game_buttons = new bool[9] { true, true, true, true, true, true, true, true, true };

        // true jesli jest tura gracza (X)
        public bool x_turn = true;

        // true jesli gra sie zakonczyla
        public bool game_finish = false;

        // pole tekstowe informujace ktory gracz wykonuje ruch
        public string player_turn = "Player: X";

        internal string[] newGame()
        {
            // wypelnienie pol gry pustym elementem
            for (var i = 0; i < game_fields.Length; i++)
            {
                game_fields[i] = " ";
                game_buttons[i] = true;
            }

            x_turn = true;
            game_finish = false;
            return game_fields;
        }

        internal bool[] buttonEnable()
        {
            for (var i = 0; i < game_buttons.Length; i++)
                game_buttons[i] = true;
            
            return game_buttons;
        }

        internal void changePlayer()
        {
            // zmiana tury gracza
            if (x_turn)
                x_turn = false;
            else
                x_turn = true;
        }

        internal bool[] buttonClicked(string[] game_fields, bool[] game_buttons, int field)
        {
            if ((game_fields[field].Equals("X")) ^ (game_fields[field].Equals("O")))
                game_buttons[field] = false;

            return game_buttons;
        }

        internal string[] fieldClick(string[] game_fields, bool x_turn, int field)
        {
            // wypelnienie pola gry w zaleznosci od gracza
            if (x_turn)
                game_fields[field] = "X";
            else
                game_fields[field] = "O";

            // sprawdzenie czy ktorys gracz wygral
            if ((game_fields[0].Equals("X")) & (game_fields[1].Equals("X")) & (game_fields[2].Equals("X")) ^ (game_fields[0].Equals("O")) & (game_fields[1].Equals("O")) & (game_fields[2].Equals("O")))
                game_finish = true;
            else if ((game_fields[3].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[5].Equals("X")) ^ (game_fields[3].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[5].Equals("O")))
                game_finish = true;
            else if ((game_fields[6].Equals("X")) & (game_fields[7].Equals("X")) & (game_fields[8].Equals("X")) ^ (game_fields[6].Equals("O")) & (game_fields[7].Equals("O")) & (game_fields[8].Equals("O")))
                game_finish = true;
            else if ((game_fields[0].Equals("X")) & (game_fields[3].Equals("X")) & (game_fields[6].Equals("X")) ^ (game_fields[0].Equals("O")) & (game_fields[3].Equals("O")) & (game_fields[6].Equals("O")))
                game_finish = true;
            else if ((game_fields[1].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[7].Equals("X")) ^ (game_fields[1].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[7].Equals("O")))
                game_finish = true;
            else if ((game_fields[2].Equals("X")) & (game_fields[5].Equals("X")) & (game_fields[8].Equals("X")) ^ (game_fields[2].Equals("O")) & (game_fields[5].Equals("O")) & (game_fields[8].Equals("O")))
                game_finish = true;
            else if ((game_fields[0].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[8].Equals("X")) ^ (game_fields[0].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[8].Equals("O")))
                game_finish = true;
            else if ((game_fields[2].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[6].Equals("X")) ^ (game_fields[2].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[6].Equals("O")))
                game_finish = true;
            else if ((game_fields[0].Equals("X") ^ game_fields[0].Equals("O")) & (game_fields[1].Equals("X") ^ game_fields[1].Equals("O")) & (game_fields[2].Equals("X") ^ game_fields[2].Equals("O")) & (game_fields[3].Equals("X") ^ game_fields[3].Equals("O")) & (game_fields[4].Equals("X") ^ game_fields[4].Equals("O")) & (game_fields[5].Equals("X") ^ game_fields[5].Equals("O")) & (game_fields[6].Equals("X") ^ game_fields[6].Equals("O")) & (game_fields[7].Equals("X") ^ game_fields[7].Equals("O")) & (game_fields[8].Equals("X") ^ game_fields[8].Equals("O")))
            {
                MessageBox.Show("Round ended as a draw !", "Draw !");
                return newGame();
            }

            if ((game_finish) & (x_turn))
            {
                MessageBox.Show("Player X won !", "Victory !");
                return newGame();
            } else if ((game_finish) & (x_turn == false))
            {
                MessageBox.Show("Player O won !", "Victory !");
                return newGame();
            }

            // zmiana gracza
            changePlayer();
            return game_fields;
        }

        internal string playerTurn(string player_turn, bool x_turn)
        {
            if(x_turn)
                return player_turn = "Player: X";
            else
                return player_turn = "Player: O";
        }
    }
}
