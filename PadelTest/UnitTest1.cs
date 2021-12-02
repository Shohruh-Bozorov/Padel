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


        // TESTING PLAYER Class


        //testing player score
        // optomised Player class to create score class automatically / Kamran
        [Fact]
        public void Test_PlayerScore()
        {
            var player = new Player("Kamran");
            player.Point();

            Assert.Equal(1, player.Score._Score);
        }


        //testing Player name string
        [Fact]
        public void Test_PlayerName()
        {
            var player = new Player("Vidar");
            string name = "Vidar";

            Assert.Equal(name, player.Name);
        }

        // TESTING GAME Class

        // test incresing score to player
        [Fact]
        public void Test_PointIsWorking()
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


        //testing to see if match point logic works.
        //logic failed, swapped game point to 4 from 3, works now.
        // Kamran
        [Fact]
        public void Test_GamePointLogic()
        {
            var player1 = new Player("Jerry");
            var player2 = new Player("James");
            var game = new Game(player1, player2);
            for (int i = 0; i < 3; i++)
            {
                game.Point(player1);
                game.Point(player2);
            }
            game.Point(player1);
            game.Point(player1);

            int expected = 5;

            Assert.Equal(expected, player1.Score._Score);
        }


        //Testing the display score
        // Kamran
        [Fact]
        public void Test_DisplayScoreWorks()
        {
            var player1 = new Player("Jerry");
            var player2 = new Player("James");
            var game = new Game(player1, player2);

            //testing for player one
            for (int i = 0; i < 5; i++)
            {
                game.Point(player1);
            }
            string s = game.ScoreString();
            string expected = "Player 1 wins";

            //testing for player2
            for (int i = 0; i < 5; i++)
            {
                game.Point(player2);
            }
            string f = game.ScoreString();
            player1.Score._Score = 0;
            string k = game.ScoreString();
            string expectedForPlayer2 = "Player 2 wins";

            Assert.Equal(expected, s);

            // should be equal because score for player 1 is reset.
            Assert.Equal(expectedForPlayer2, k);

            // should not be equal since player1 score is already 5
            Assert.NotEqual(expectedForPlayer2, f);
        }



    }
}
