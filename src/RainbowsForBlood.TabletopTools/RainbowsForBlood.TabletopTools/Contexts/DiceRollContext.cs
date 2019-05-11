using System;
using System.Collections.Generic;
using System.Text;

namespace RainbowsForBlood.TabletopTools.Contexts
{
    public class DiceRollContext
    {
        internal List<(int NumberOfDice, int Sides)> Dice { get; set; }

        internal int Modifier { get; set; }
    }
}
