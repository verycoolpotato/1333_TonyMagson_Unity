using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame.Scripts.HelperClasses

{
    public class DieRoller
    {
        protected Random random;

        public DieRoller()
        {
            // Initialize Random instance once
            random = new Random();
        }

        /// <summary>
        /// Takes a die and rolls it, returns rolled value
        /// </summary>
        /// <param name="die"></param>
        /// <returns></returns>
        public int Roll(int min, int max)
        {
            int result = random.Next(min, max + 1);

            return result;
        }
        /// <summary>
        /// returns a random number from an int array 
        /// </summary>
        /// <param name="choices"></param>
        /// <returns></returns>
        public int PickRandomDie(int[] choices)
        {
            int die = random.Next(0, choices.Length);

            return choices[die];
        }

    }

}
