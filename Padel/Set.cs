using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        List<Game> _games = new List<Game>();
        public Player _player1;
        public Player _player2;


        // changed to take in game instead of player
        // first to 6 games. if it is 5-5 then play to 7. if 6-6 play one last game


        // Tested By Vidar
        // index is not needed in this method because the purpose is just  to add score to one of the players
        // Did not add GamesWon as expexted
        public void Point(Game game, Player player)
        {
            //loop how many times it should add a point.
            _games.Add(game);
            game.Point(player);
        }

        public string SetScore()
        {
            // System.NullReferenceException was thrown
            // The players in this method is never used


            return $"The score is \n" +
                $"Player one: {_player1.GamesWon} - {_player2.GamesWon}";
        }
    }
}
