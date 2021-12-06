using System;
using System.Collections.Generic;

namespace Padel
{
    public class Match
    {
        List<Set> _sets;
        public Player _player1;
        public Player _player2;
        public Match(int numberOfSets, Player player1, Player player2)
        {
            _sets = new List<Set>(numberOfSets);
            for (int i = 0; i < numberOfSets; i++)
            {
                _sets.Add(new Set());
            }
            _player1 = player1;
            _player2 = player2;
        }

        public void Point(Set set, int index)
        {
            _sets[index] = set; 
        }

        //might be wrong logic
        public string MatchScore()
        {
            if (_player1.SetsWon == 3)
                return "Player one has won the match";
            else if (_player2.SetsWon == 3)
                return "Player two has won the match";

            return $"The score is \n" +
                $"Player one: {_player1.SetsWon} - {_player2.SetsWon}";
        }
    }
}
