using System.Collections.Generic;

namespace Spellcaster
{
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
}