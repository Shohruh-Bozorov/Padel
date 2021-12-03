using System;

namespace Padel
{
    public class Player
    {
        public string Name { set; get; }
        public Score Score { set; get; } = new Score();
        
        public Player(string name)
        {
            Name = name;
            // borde man inte skapa instansen här på constructorn? för då skapas det ju en instans för båda spelarna. 
            Score = new Score();
        }
        
        
        public void Point()
        {
            Score.Increase();
        }
    }
}
