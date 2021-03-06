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
        ///

        // Testing score
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

        // Testing so player starts with correct score
        // Vidar

        [Fact]
        public void Test_NewPlayer_Score()
        {
            var player = new Player("John");

            Assert.True(player.Score._Score == 0);
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
            int score1 = (game.Score(player1));
            int score2 = (game.Score(player2));

            Assert.True(score1 == score2);
        }

        // test get players score when score is false
        // Vidar       
        [Fact]
        public void Test_Get_Players_Score_False()
        {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var game = new Game(player1, player2);
            game.Point(player1); // Giving Score to player1
            int score1 = (game.Score(player1));
            int score2 = (game.Score(player2));

            Assert.False(score1 == score2);
        }

        // test if exception is thrown in Score method when player does not exist in game
        // Vidar
        [Fact]
        public void Test_ScoreException()
        {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var player3 = new Player("James");
            var game = new Game(player1, player2);


            Assert.Throws<FormatException>(() => game.Score(player3));
        }


        //testing to see if match point logic works.
        //logic failed, swapped game point to 4 from 3.
        //Fails, but for the wrong reason.
        // Only fails because our score resets as soon as it hits 4.
        // In reality the logic I wanted to test passes.
        // If a player wins with 2 points when the score is 40-40, that player gets a game point.
        // I guess in this case the expected should be 0.
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

            int expected = 4;

            Assert.Equal(expected, player1.Score._Score);
        }

        [Fact]
        // testing to see if the score is resets.
        //Kamran
        public void Test_ScoreResetsCorrectly()
        {
            var player = new Player("Jim");
            var player2 = new Player("Bob");
            var game = new Game(player, player2);

            for (int i = 0; i < 4; i++)
            {
                game.Point(player);
            }

            int expected = 0;
            Assert.Equal(expected, game.Score(player));
        }


        // Testing the display score method
        // Doesn't work becaue score is reset as soon as the score is 4.
        // Score String only returns who won if a players score remains 4.
        // Kamran
        [Fact]
        public void Test_DisplayScoreWorks()
        {
            var player1 = new Player("Jerry");
            var player2 = new Player("James");
            var game = new Game(player1, player2);

            //testing for player one
            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
            }
            string s = game.ScoreString();
            string expected = "Player 1 wins";

            //testing for player2
            for (int i = 0; i < 4; i++)
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

        // testing to see if score string returns undecided if game isn't won yet.
        // Kamran
        [Fact]
        public void Test_ReturnsUndecided()
        {
            var player = new Player("Jim");
            var player2 = new Player("Bob");
            var game = new Game(player, player2);

            game.Point(player);
            string expected = "Undecided";

            Assert.Equal(expected, game.ScoreString());
        }


        //Testing game constructor
        // Vidar

        [Theory]
        [InlineData("John", "Beck")]
        [InlineData("1", "2")]
        public void Test_GameConstructor(string name1, string name2)
        {
            var game = new Game(new Player(name1), new Player(name2));
            Assert.True(game.Player1.Name == name1 && game.Player2.Name == name2);
        }

        // Testing if you need to win with two points
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
            game.Point(player1);

            // Give player2 3 points
            game.Point(player2);
            game.Point(player2);
            game.Point(player2);
            game.Point(player2);

            // Give player1 extra point but should still be 3 because you need to win with 2 points
            // player2 should have 2 points
            game.Point(player1);


            Assert.True(player1.Score._Score == 4 && player2.Score._Score == 3);
        }


        //Testing players score reset after wining game
        // Vidar

        [Fact]
        public void Test_Player_Score_Reset()
        {
            var player1 = new Player("John");
            var player2 = new Player("Betty");
            var game = new Game(player1, player2);
            for (int i = 0; i < 5; i++)
            {
                game.Point(player1);
            }

            Assert.True(player1.Score._Score == 0);
        }

        // Test if added field gamePoints is added correctly in point method in player class.
        // Vidar
        [Fact]
        public void Test_Game_Point_Incresse()
        {
            var player = new Player("Alan");
            for (int i = 0; i < 4; i++)
            {
                player.Point();
            }
            Assert.True(player.GamesWon == 1);
        }


        // TESTING SET Class


        // Test creatinng new Set to see if it contains something
        // Vidar

        [Fact]
        public void Test_CreatingNewSet()
        {
            var newSet = new Set();

            Assert.Null(newSet);
            // Contains two players
        }

        // Test if players in Set contains something
        // Vidar

        [Fact]
        public void Test_PlayersContains()
        {
            var set = new Set();
            Assert.Null(set._player1);
            Assert.Null(set._player2);
            // Players is null
        }

        // Test point method if you can add score
        //Vidar

        [Fact]
        public void Test_PointMethod_SetClass()
        {
            var player1 = new Player("p1");
            var player2 = new Player("p2");
            var game = new Game(player1, player2);
            var set = new Set();
            set.Point(game, player1);
            set.Point(game, player1);
            Assert.Equal(2, player1.Score._Score);

        }

        // Test point method if GamesWon is incressed when wining one Game
        // Vidar

        [Fact]
        public void Test_GamesWonIncressed()
        {
            var player1 = new Player("p1");
            var player2 = new Player("p2");
            var game = new Game(player1, player2);
            var set = new Set();

            for (int i = 0; i < 4; i++)
            {
                set.Point(game, player1);
            }

            Assert.Equal(1, player1.GamesWon);

            // Noticed here that the index was not needed
        }

        // Test adding score to two different games to see if GamesWon was incressed
        // Vidar

        [Fact]
        public void Test_AddingScoreInDifferentGames()
        {
            var player1 = new Player("p1");
            var player2 = new Player("p2");
            var game = new Game(player1, player2);
            var game2 = new Game(player1, player2);
            var set = new Set();

            for (int i = 0; i < 4; i++)
            {
                set.Point(game, player1);
            }
            for (int i = 0; i < 4; i++)
            {
                set.Point(game2, player1);
            }

            Assert.Equal(2, player1.GamesWon);

            // Failed
        }

        //Test if SetScore method works
        // Vidar

        [Fact]
        public void Test_SetScoreMethod()
        {
            var player1 = new Player("p1");
            var player2 = new Player("p2");
            var game = new Game(player1, player2);
            var set = new Set();

            for (int i = 0; i < 4; i++)
            {
                set.Point(game, player1);
            }
            Assert.NotNull(set.SetScore());

            // System.NullReferenceException was thrown
        }


        // Testing MATCH class

        // Testing to see if the constructor creates the right amount of sets.
        // Kamran
        [Fact]
        public void Test_MatchConstructor()
        {
            var player = new Player("Jim");
            var player2 = new Player("Bob");
            var match = new Match(3, player, player2);

            int counter = 0;
            int expected = 3;

            foreach (var item in match._sets)
            {
                counter++;
            }

            Assert.Equal(expected, counter);
        }

        [Fact]
        // Testing to see if you can add points to a player through a match instance.
        // Kamran
        public void Test_MatchAddsPoint()
        {
            var player = new Player("Jim");
            var player2 = new Player("Bob");
            var match = new Match(3, player, player2);

            match.Point(player);

            Assert.Equal(1, player.Score._Score);

        }

        [Fact]
        // checking to see what happens when I add points to a player outside of a match
        // Kamran
        public void Test_AddPointsToOutsidePlayer()
        {
            var player = new Player("Jim");
            var player2 = new Player("Bob");
            var player3 = new Player("Bob");
            var match = new Match(3, player, player2);

            match.Point(player3);

            int expected = 0;

            Assert.Equal(expected, player3.Score._Score);
        }

        [Fact]
        // testing to see if MatchPoint works
        // Kamran
        public void Test_MatchPoint()
        {
            var player = new Player("Jim");
            var player2 = new Player("Bob");
            var player3 = new Player("Bob");
            var match = new Match(3, player, player2);
            player.SetsWon = 3;
            string expected = "Player one has won the match";

            Assert.Equal(expected, match.MatchScore());
        }
    }
}
