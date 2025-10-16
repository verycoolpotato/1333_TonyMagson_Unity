using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;


namespace DiceGame.Scripts.Rooms
{
  
    internal abstract class Room
    {
        
        public enum Direction
        {
            None,
            North,
            East,
            South,
            West 
        }

        public Dictionary<Direction,Room> RoomRefs = new Dictionary<Direction, Room>() { 
            {Direction.North, null}, 
            {Direction.East, null},
            {Direction.South, null},
            {Direction.West, null}
        };

        

        private WorldManager _worldManager;

        //state of this room?
        protected bool _revealed = false;
        protected bool _visited = false;
        protected bool _empty = false;
        #region Connections

        public void SetWorld(WorldManager world)
        {
              _worldManager = world;
        }

       
        

      

       
        #endregion

        #region AbstractClasses

        /// <summary>
        /// what room is this?
        /// </summary>
        protected abstract string RoomDescription();

        /// <summary>
        /// What happens when using the search action
        /// </summary>
        public virtual void OnRoomSearched(Player player = null)
        {

        }

        protected virtual void EnteredEvent()
        {
            //Do nothing by default
        } 

        #endregion

        #region Exploration
        

        public abstract string RoomIcon();
       

        /// <summary>
        /// Describes the room and returns whether its been visited
        /// </summary>
        /// <returns></returns>
        public void OnRoomEnter()
        {
            

            Console.WriteLine(RoomDescription());
            
            EnteredEvent();
          
        }

        /// <summary>
        /// Marks the room as visited and prints exit message
        /// </summary>
        public void OnRoomExit()
        {
            Console.WriteLine("...Leaving Room");
           
        }
        #endregion

    }
}
