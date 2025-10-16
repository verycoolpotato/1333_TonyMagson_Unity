using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.HelperClasses
{
    internal static class InputHelper
    {
        internal static int GetIntInput()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                char keyChar = keyInfo.KeyChar;

                if (char.IsDigit(keyChar))
                {
                    return keyChar - '0'; 
                }

                
            }
        }


        internal static string GetStringInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                return input;
            } 
        }

    }
}
