using DiceGame.Scripts.CoreSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DiceGame.Scripts.Creatures
{
    internal abstract class Creature : MonoBehaviour
    {


        private int _health;
        internal int Health
        {
            get { return _health; }
            set 
            {
                _health = value;
                _health = Math.Clamp(_health, 0, _maxHealth);
            
            }
        }
        internal string Name;
        protected int _maxHealth;
        internal Inventory inventory;

      

        private void Awake()
        {
            _maxHealth = _health;
            Health = _health;
        }




    }
}
