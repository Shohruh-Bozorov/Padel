using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        List<Game> _games = new List<Game>();

        public void Point(Game game)
        {

            _games.Add(game);

        }
    }
}
