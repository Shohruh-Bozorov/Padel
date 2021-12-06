using System;

namespace Padel
{
    public class Player
    {
        public string Name { set; get; }
        public Score Score { set; get; } = new Score();
        public int GamesWon;
        public int SetsWon;
        
        public Player(string name)
        {
            Name = name;
        }
        
        
        public void Point()
        {
            Score.Increase();

            if (Score._Score == 4)
                GamesWon++;
            if (GamesWon == 6)
                SetsWon++;
        }
    }
}
