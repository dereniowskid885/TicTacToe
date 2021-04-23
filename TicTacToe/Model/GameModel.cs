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

        // true jesli jest tura gracza (X)
        public bool x_turn = true;

        // true jesli gra sie zakonczyla
        public bool game_finish;

        // pole tekstowe informujace ktory gracz wykonuje ruch
        public string player_turn = "Player: X";

        internal string[] newGame()
        {
            // wypelnienie pol gry pustym elementem
            for (var i = 0; i < game_fields.Length; i++)
                game_fields[i] = " ";

            x_turn = true;
            return game_fields;
        }

        internal void changePlayer()
        {
            if (x_turn)
                x_turn = false;
            else
                x_turn = true;
        }

        internal string[] fieldClick(string[] game_fields, bool x_turn, int field)
        {
            if (x_turn)
                game_fields[field] = "X";
            else
                game_fields[field] = "O";

            if ((game_fields[0].Equals("X")) & (game_fields[1].Equals("X")) & (game_fields[2].Equals("O")) ^ (game_fields[0].Equals("O")) & (game_fields[1].Equals("O")) & (game_fields[2].Equals("O")))
                game_finish = true;
            else if ((game_fields[3].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[5].Equals("O")) ^ (game_fields[3].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[5].Equals("O")))
                game_finish = true;
            else if ((game_fields[6].Equals("X")) & (game_fields[7].Equals("X")) & (game_fields[8].Equals("O")) ^ (game_fields[6].Equals("O")) & (game_fields[7].Equals("O")) & (game_fields[8].Equals("O")))
                game_finish = true;
            else if ((game_fields[0].Equals("X")) & (game_fields[3].Equals("X")) & (game_fields[6].Equals("O")) ^ (game_fields[0].Equals("O")) & (game_fields[3].Equals("O")) & (game_fields[6].Equals("O")))
                game_finish = true;
            else if ((game_fields[1].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[7].Equals("O")) ^ (game_fields[1].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[7].Equals("O")))
                game_finish = true;
            else if ((game_fields[2].Equals("X")) & (game_fields[5].Equals("X")) & (game_fields[8].Equals("O")) ^ (game_fields[2].Equals("O")) & (game_fields[5].Equals("O")) & (game_fields[8].Equals("O")))
                game_finish = true;
            else if ((game_fields[0].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[8].Equals("O")) ^ (game_fields[0].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[8].Equals("O")))
                game_finish = true;
            else if ((game_fields[2].Equals("X")) & (game_fields[4].Equals("X")) & (game_fields[6].Equals("O")) ^ (game_fields[2].Equals("O")) & (game_fields[4].Equals("O")) & (game_fields[6].Equals("O")))
                game_finish = true;

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
