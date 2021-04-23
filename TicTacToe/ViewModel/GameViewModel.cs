using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    using Model;

    class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.GameModel game = new Model.GameModel();

        public string[] fields
        {
            get { return game.game_fields; }
            set
            {
                game.game_fields = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(fields)));
            }
        }

        private ICommand new_game;

        public ICommand newGame
        {
            get
            {
                return new_game ?? (new_game = new BaseClass.RelayCommand((p) => {
                    fields = game.newGame();
                    playerTurn = "Player: X";
                }, p => true));
            }
        }

        public string playerTurn
        {
            get { return game.player_turn; }
            set
            {
                game.player_turn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(playerTurn)));
            }
        }

        private ICommand field_click;

        public ICommand fieldClick
        {
            get
            {
                return field_click ?? (field_click = new BaseClass.RelayCommand((p) => {
                    fields = game.fieldClick(game.game_fields, game.x_turn, 0);
                    playerTurn = game.playerTurn(game.player_turn, game.x_turn);
                }, p => true));
            }
        }
    }
}
