using System;
using Xunit;
using Padel;

namespace PadelTest
{
    // Vidar test
    public class UnitTest1
    {
        //[Fact]
        //public void Test1()
        //{
        //    //Exempel p? anv?ndning:
        //    Player player1 = new Player("Player 1");
        //    Player player2 = new Player("Player 2");

        //    var game = new Game(player1, player2);
        //    game.Point(player1); // 15 - 0
        //    game.Point(player1); // 30 - 0
        //    game.Point(player2); // 30 - 15
        //    game.Point(player1); // 40 - 15
        //    game.Point(player1); // Player 1 vinner Gamet

        //    var result = game.ScoreString(); // Ska vara Player 1 wins Game

        //    //test
        //}


        /// <summary>
        /// Testing Score file
        /// </summary>
        [Fact]
        public void Test_ScoreAddition()
        {
            var score = new Score();
            score.Increase();

            Assert.Equal(1, score._Score);

        }


        // TESTING PLAYER


        //testing player score
        [Fact]
        public void Test_PlayerScore()
        {
            var player = new Player("Kamran");
            player.Score = new Score();
            player.Point();

            Assert.Equal(1, player.Score._Score);
        }


        //testing Player name string
        [Fact]
        public void Test_PlayerName()
        {
            var player = new Player("q");
            string name = "Vidar";

            Assert.Equal(name, player.Name);
        }
        
        // test incressing score to player
        [Fact]
        public void Test_IsPointWorking()
        {
            var vidar = new Player("Vidar");
            var kamran = new Player("Kamran");
            var game = new Game(vidar, kamran);
            game.Point(vidar);
            //game.Point(kamran);

            Assert.Equal(1, game.Player1.Score._Score);


        }

    }
}
