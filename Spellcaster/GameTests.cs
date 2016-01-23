using NSubstitute;
using NUnit.Framework;

namespace Spellcaster
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void GameSetup_InitialSetup_FirstPlayersHealthIsSet()
        {
            // Arrange

            // Act
            _game.Initialize();

            // Assert
            Assert.AreEqual(15, _game.Player1.Health);
        }

        [Test]
        public void GameSetup_InitialSetup_SecondPlayersHealthIsSet()
        {
            // Arrange

            // Act
            _game.Initialize();

            // Assert
            Assert.AreEqual(15, _game.Player2.Health);
        }

        [Test]
        public void GameSetup_InitialSetup_PlayersMoveListsAreEmpty()
        {
            // Arrange

            // Act
            _game.Initialize();

            // Assert
            Assert.AreEqual(0, _game.Player2.LeftGestures.Count);
        }

        [Test]
        public void MakeGesture_PlayerMakesDoubleFingerGesture_PlayersMoveListContainsDoubleFingerGesture()
        {
            // Arrange
            _game.Initialize();

            // Act
            _game.Player1.MakeGesture(Gesture.Finger, Gesture.Finger);
            var result = _game.Player1.LeftGestures.Contains(Gesture.Finger) && _game.Player1.RightGestures.Contains(Gesture.Finger);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void MakeGesture_PlayerMakesDoubleWaveGesture_PlayersMoveListContainsDoubleWaveGesture()
        {
            // Arrange
            _game.Initialize();

            // Act
            _game.Player1.MakeGesture(Gesture.Wave, Gesture.Wave);
            var result = _game.Player1.LeftGestures.Contains(Gesture.Wave) && _game.Player1.RightGestures.Contains(Gesture.Wave);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void MakeGesture_PlayerMakesOneGesture_PlayersMoveListContainsOneGesture()
        {
            // Arrange
            _game.Initialize();

            // Act
            _game.Player1.MakeGesture(Gesture.Wave, Gesture.Finger);
            var result = _game.Player1.LeftGestures.Count + _game.Player1.RightGestures.Count;

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CastSpell_PlayerOneCastsStab_TargetsHealthIsFourteen()
        {
            // Arrange
            _game.Initialize();

            // Act
            _game.CastSpell(_game.Player1, new Stab {Target = _game.Player2});
            var result = _game.Player2.Health;

            // Assert
            Assert.AreEqual(14, result);
        }


        [Test]
        public void CastSpell_PlayerOneCastsCauseLightWounds_TargetsHealthIsThirteen()
        {
            _game.Initialize();

            // Act
            _game.CastSpell(_game.Player1, new CauseLightWounds {Target = _game.Player2});
            var result = _game.Player2.Health;

            // Assert
            Assert.AreEqual(13, result);
        }

        [Test]
        public void CastSpell_PlayerTwoCastsStabPlayerTwoCastsShield_TargetsIsNotDamaged()
        {
            _game.Initialize();

            // Act
            _game.CastSpell(_game.Player1, new Shield {Target = _game.Player1});
            _game.CastSpell(_game.Player2, new Stab {Target = _game.Player1});

            // Assert
            var result = _game.Player1.Health;
            Assert.AreEqual(15, result);
        }

    }

    
}