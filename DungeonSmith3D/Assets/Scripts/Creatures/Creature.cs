using DiceGame.Scripts.CoreSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Creatures
{
    internal abstract class Creature
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

        protected Creature(int health)
        {
            _maxHealth = health;
            Health = health;
           
        }
        protected Creature(int health, string name)
        {
            _maxHealth = health;
            Health = health;
            Name = name;
            
        }

        

        

    }
}
