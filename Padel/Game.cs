using System;

namespace Padel
{

    public class Game
    {
        private Player _player1;
        private Player _player2;

        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player1 = player2;
        }

        public void Point(Player player)
        {
            _player1.Point();
        }

        public Score Score()
        {
            return _player1.Score;
        }

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
