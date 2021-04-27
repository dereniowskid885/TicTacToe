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

        public bool[] buttonUse
        {
            get { return game.game_buttons; }
            set
            {
                game.game_buttons = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(buttonUse)));
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

        private ICommand new_game;
        public ICommand newGame
        {
            get
            {
                return new_game ?? (new_game = new BaseClass.RelayCommand((p) => {
                    fields = game.newGame();
                    playerTurn = "Player: X";
                    buttonUse = game.buttonEnable();
                }, p => true));
            }
        }

        public ICommand clickEvent(ICommand field_click, int field)
        {
            return field_click ?? (field_click = new BaseClass.RelayCommand((p) => {
                fields = game.fieldClick(game.game_fields, game.x_turn, field);
                playerTurn = game.playerTurn(game.player_turn, game.x_turn);
                buttonUse = game.buttonClicked(game.game_fields, game.game_buttons, field);
            }, p => true));
        }

        private ICommand field_click_0_0, field_click_0_1, field_click_0_2, field_click_1_0, field_click_1_1, field_click_1_2, field_click_2_0, field_click_2_1, field_click_2_2;
        public ICommand fieldClick_0_0 { get { return clickEvent(field_click_0_0, 0); } }
        public ICommand fieldClick_0_1 { get { return clickEvent(field_click_0_1, 3); } }
        public ICommand fieldClick_0_2 { get { return clickEvent(field_click_0_2, 6); } }
        public ICommand fieldClick_1_0 { get { return clickEvent(field_click_1_0, 1); } }
        public ICommand fieldClick_1_1 { get { return clickEvent(field_click_1_1, 4); } }
        public ICommand fieldClick_1_2 { get { return clickEvent(field_click_1_2, 7); } }
        public ICommand fieldClick_2_0 { get { return clickEvent(field_click_2_0, 2); } }
        public ICommand fieldClick_2_1 { get { return clickEvent(field_click_2_1, 5); } }
        public ICommand fieldClick_2_2 { get { return clickEvent(field_click_2_2, 8); } }
    }
}
