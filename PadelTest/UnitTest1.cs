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
      
        
        // TESTING SCORE Class
        
        [Fact]
        public void Test_ScoreAddition()
        {
            var score = new Score();
            score.Increase();

            Assert.Equal(1, score._Score);

        }


        // TESTING PLAYER Class


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
            //string name = "q";

            Assert.Equal(name, player.Name);
        }

        // Testing Players score when new palyer is made
        // Vidar

        [Fact]
        public void Test_NewPlayer_Score()
        {
            var player = new Player("John");

            Assert.True(player.Score._Score == 0);
        }

        // TESTING GAME Class

        // test that game constructor creates two players with names
        // Vidar
      
        [Theory]
        [InlineData("John", "Beck")]
        [InlineData("1", "2")]
        public void Test_GameConstructor1(string name1, string name2)
        {
            var game = new Game(new Player(name1), new Player(name2));
            Assert.True(game.Player1.Name == name1 && game.Player2.Name == name2);
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

      
        // test get players score when score is same
        // Vidar       
        [Fact]
        public void Test_Get_Players_Score_True()
        {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var game = new Game(player1, player2);
            var score1 = (game.Score(player1));
            var score2 = (game.Score(player2));

            Assert.True (score1._Score == score2._Score);
        }

        // test get players score when score is false
        // Vidar       
        [Fact]
        public void Test_Get_Players_Score_False()
        {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var game = new Game(player1, player2);
            game.Point(player1);
            var score1 = (game.Score(player1));
            var score2 = (game.Score(player2));

            Assert.False(score1._Score == score2._Score);
        }

        // test if exeption is thrown in Score method when player does not exist in game
        // Vidar
        [Fact]
         public void Test_ScoreExetion()
         {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var player3 = new Player("James");
            var game = new Game(player1, player2);


            Assert.Throws<FormatException>(() => game.Score(player3));
         }

        // Testing if you can win with only one point
        // Vidar

        [Fact]
        public void Test_AddScore_When_Tie()
        {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var game = new Game(player1, player2);

            // Give palyer1 3 points
            game.Point(player1);
            game.Point(player1);
            game.Point(player1);

            // Give player2 3 points
            game.Point(player2);
            game.Point(player2);
            game.Point(player2);

            // Give player1 extra point but should still be 3 because you need to win with 2 points
            // player2 should have 2 points
            game.Point(player1);
            

            Assert.True(player1.Score._Score == 3 && player2.Score._Score == 2);
        }

        // TESING SET Class



    }
}
