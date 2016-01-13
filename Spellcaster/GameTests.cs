using NSubstitute;
using NUnit.Framework;

namespace Spellcaster
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameSetup_InitialSetup_FirstPlayersHealthIsSet()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);

            // Act
            game.Initialize();

            // Assert
            Assert.AreEqual(15, player1.Health);
        }

        [Test]
        public void GameSetup_InitialSetup_SecondPlayersHealthIsSet()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);

            // Act
            game.Initialize();

            // Assert
            Assert.AreEqual(15, player2.Health);
        }

        [Test]
        public void GameSetup_InitialSetup_PlayersMoveListsAreEmpty()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);

            // Act
            game.Initialize();

            // Assert
            Assert.AreEqual(0, player2.LeftGestures.Count);
        }

        [Test]
        public void MakeGesture_PlayerMakesDoubleFingerGesture_PlayersMoveListContainsDoubleFingerGesture()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);
            game.Initialize();

            // Act
            player1.MakeGesture(Gesture.Finger, Gesture.Finger);
            var result = player1.LeftGestures.Contains(Gesture.Finger) && player1.RightGestures.Contains(Gesture.Finger);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void MakeGesture_PlayerMakesDoubleWaveGesture_PlayersMoveListContainsDoubleWaveGesture()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);
            game.Initialize();

            // Act
            player1.MakeGesture(Gesture.Wave, Gesture.Wave);
            var result = player1.LeftGestures.Contains(Gesture.Wave) && player1.RightGestures.Contains(Gesture.Wave);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void MakeGesture_PlayerMakesOneGesture_PlayersMoveListContainsOneGesture()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);
            game.Initialize();

            // Act
            player1.MakeGesture(Gesture.Wave, Gesture.Finger);
            var result = player1.LeftGestures.Count + player1.RightGestures.Count;

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CastSpell_PlayerOneCastsStab_TargetsHealthIsFourteen()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);
            game.Initialize();

            // Act
            game.CastSpell(player1, new Stab {Target = player2});
            var result = player2.Health;

            // Assert
            Assert.AreEqual(14, result);
        }

        [Test]
        public void CastSpell_PlayerOneCastsCauseLightWounds_TargetsHealthIsThirteen()
        {
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);
            game.Initialize();

            // Act
            game.CastSpell(player1, new CauseLightWounds {Target = player2});
            var result = player2.Health;

            // Assert
            Assert.AreEqual(13, result);
        }

        [Test]
        public void CastSpell_PlayerTwoCastsStabPlayerTwoCastsShield_TargetsIsNotDamaged()
        {
            var player1 = new Player();
            var player2 = new Player();
            var game = new Game(player1, player2);
            game.Initialize();

            // Act
            game.CastSpell(player1, new Shield {Target = player1});
            game.CastSpell(player2, new Stab {Target = player1});

            var result = player1.Health;
            // Assert
            Assert.AreEqual(15, result);
        }


    }

    
}