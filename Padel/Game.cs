using System;

namespace Padel
{
    // doesn't include player2
    // Player 2 doesn't seem to be needed
    public class Game
    {
        private Player _player1;
        public Player Player1 { get { return _player1; } }
        private Player _player2;
        public Player Player2 { get { return _player2; } }


        // Adjusting constructor logic to set both players
        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        // Adding logic so both players can get points
        public void Point(Player player)
        {
            if (player.Name == _player1.Name)
            {
                _player1.Point();
            }
            if (player.Name == _player2.Name)
            {
                _player2.Point();
            }
        }


        // doesn't return player2
        // added parameter to determine player
        //
        public Score Score(Player player)
        {
            if (_player1.Name == player.Name)
                return _player1.Score;
            else if (_player2.Name == player.Name)
                return _player2.Score;

            else throw new FormatException("Incorrect player");
        }


        // logic wrong
        public string ScoreString()
        {
            if (_player1.Score._Score > 4)
            {
                return "Player 1 wins";
            }
            return "Player 2 wins";
        }
    }
}
