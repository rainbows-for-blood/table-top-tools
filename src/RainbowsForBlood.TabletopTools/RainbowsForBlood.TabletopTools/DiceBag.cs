using RainbowsForBlood.TabletopTools.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RainbowsForBlood.TabletopTools
{
    public static class DiceBag
    {
        public static DiceRollContext DiceRoll()
        {
            return new DiceRollContext
            {
                Dice = new List<(int NumberOfDice, int Sides)>(),
                Modifier = 0
            };
        }

        public static DiceRollContext AddDice(this DiceRollContext context, int sides)
        {
            context.Dice.Add((1, sides));
            return context;
        }

        public static DiceRollContext AddDice(this DiceRollContext context, int numberOfDice, int sides)
        {
            context.Dice.Add((numberOfDice, sides));
            return context;
        }

        public static DiceRollContext AddDice(this DiceRollContext context, string diceCode)
        {
            int numberOfDice;
            int sides;

            diceCode = diceCode.ToLower();
            
            if(diceCode.StartsWith("d"))
            {
                sides = int.Parse(diceCode.Substring(1));
                return context.AddDice(sides);
            }

            var diceCodeParts = diceCode.Split('d');

            if(diceCodeParts.Length != 2)
            {
                throw new FormatException();
            }

            numberOfDice = int.Parse(diceCodeParts[0]);
            sides = int.Parse(diceCodeParts[1]);
            return context.AddDice(numberOfDice, sides);
        }
    }
}
