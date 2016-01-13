using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Spellcaster
{
    public class Player
    {
        public int Health { get; set; }

        public List<Gesture> RightGestures { get; set; }

        public List<Gesture> LeftGestures { get; set; }
        public bool IsShielded { get; set; }

        public void MakeGesture(Gesture leftGesture, Gesture rightGesture)
        {
            LeftGestures.Add(leftGesture);
            RightGestures.Add(rightGesture);
        }

        public void CastSpell(ISpell spell)
        {
            
        }
    }



    public enum Gesture
    {
        Finger,
        None,
        Wave
    }
}
