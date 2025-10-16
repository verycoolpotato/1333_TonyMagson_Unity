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



        internal int Health;
        internal string Name;
        protected int _maxHealth;
        internal Inventory inventory;

        protected Creature(int health)
        {
            Health = health;
           _maxHealth = health;
        }
        protected Creature(int health, string name)
        {
            Health = health;
            Name = name;
            _maxHealth = health;
        }

        

        

    }
}
