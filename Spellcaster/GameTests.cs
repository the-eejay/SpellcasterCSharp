using NSubstitute;
using NUnit.Framework;

namespace Spellcaster
{
    [TestFixture]
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
}