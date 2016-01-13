using System.Runtime.InteropServices;

namespace Spellcaster
{
    public interface ISpell
    {
        int Damage { get; }
        Player Target { get; set; }
    }

    public class CauseLightWounds : ISpell
    {
        public Player Target { get; set; }
        public int Damage => 2;
    }

    public class Stab : ISpell
    {
        public int Damage => 1;
        public Player Target { get; set; }
    }

    public class Shield : ISpell
    {
        public int Damage => 0;
        public Player Target { get; set; }
    }
}