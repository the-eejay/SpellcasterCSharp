using System;
using System.Collections.Generic;
using NSubstitute;

namespace Spellcaster
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();



        public Game()
        {

            _players.Add(new Player());
            _players.Add(new Player());
        }

        public Player Player1 => _players[0];
        public Player Player2 => _players[1];

        public void Initialize()
        {
            foreach (var player in _players)
            {
                player.Health = 15;
                player.LeftGestures = new List<Gesture>();
                player.RightGestures = new List<Gesture>();
            }
        }

        public void CastSpell(Player player, ISpell spell)
        {
            player.CastSpell(spell);
            if (spell.GetType() == typeof (Shield))
            {
                player.IsShielded = true;
            }
            if (!spell.Target.IsShielded)
            {
                spell.Target.Health -= spell.Damage;
            }
            
        }
    }

    
}