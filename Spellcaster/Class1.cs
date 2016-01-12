using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Spellcaster
{
    public class GameTests
    {
        [Test]
        public void GameSetup_InitialSetup_PlayersHealthSet()
        {
            // Arrange
            var player1 = Substitute.For<Player>();
            var player2 = Substitute.For<Player>();
            var game = new Game(player1, player2);
            game.Initialize();
            // Act
            var result = player1.Health;

            // Assert
            Assert.AreEqual(15, result);
        }
    }

    public class Game
    {
        private readonly List<Player> players = new List<Player>();
        public Game(Player player1, Player player2)
        {
            players.Add(player1);
            players.Add(player2);
        }

        public void Initialize()
        {
            foreach (var player in players)
            {
                player.Health = 15;
            }
        }
    }

    public class Player
    {
        public double Health { get; set; }
    }
}
