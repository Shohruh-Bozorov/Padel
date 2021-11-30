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
        }
        
        
        public void Point()
        {
            Score.Increase();
        }
    }
}
