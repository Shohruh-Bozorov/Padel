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

        // Adding logic so both players can get points.
        // Added logic to simulate match point.
        public void Point(Player player)
        {
            if (_player1.Score._Score == 4 && _player2.Score._Score == 4)
            {
                _player1.Score._Score--;
                _player2.Score._Score--;

            }

            if (player.Name == _player1.Name)
            {
                _player1.Point();
            }
            if (player.Name == _player2.Name)
            {
                _player2.Point();
            }

            //error hantering ifall namnet inte matchar varken player1 eller player2 name
            else
            {
                Console.WriteLine("Invalid name, try again!");
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
        // added else if so that the method doesn't always return player 2 wins.
        public string ScoreString()
        {
            if (_player1.Score._Score > 4)
            {
                return "Player 1 wins";
            }
            else if (_player2.Score._Score > 4)
                return "Player 2 wins";
            else return null;
        }
    }
}
