using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame.Scripts.Items.Consumables
{
    internal abstract class Consumable : Item
    {
        
      
        private void Awake()
        {
            CommandActions["Use"] = Use;
        }


      

       


    }
}
