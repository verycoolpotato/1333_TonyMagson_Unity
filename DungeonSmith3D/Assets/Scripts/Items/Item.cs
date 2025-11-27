using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
public class Item 
{
    internal string Name;

    protected Vector2Int Die;

    protected ItemStats _stats;
    public ItemStats Stats => _stats;

    public int ActionPointCost { get; protected set; }
    
  

    public Item(ItemStats stats)
    {
        _stats = stats;
        Die = _stats.ItemRollRange;
        ActionPointCost = _stats.ActionPointCost;
        Name = _stats.ThisItemName;
        
    }

    //allows looping through methods
    protected Dictionary<string, Action> CommandActions = new();

    protected virtual void DefaultCommands()
    {
     
        CommandActions["Drop"] = Drop;
       
    }

    internal virtual void Use()
    {

    }
    protected string ItemDescription()
    {
        return _stats.Description;
    }

    internal Vector2Int DieRange()
    {
        return Die;
    }

    /// <summary>
    /// removes this item from the inventory
    /// </summary>
    protected void Drop()
    {
      
        if (InputHelper.GetIntInput() == 2)
        {
            Console.WriteLine($"{Name} was dropped.");

            RemoveItem();
        }
    }

    protected void RemoveItem()
    {
        Inventory inventory = GameManager.Instance!.GamePlayer.PlayerInventory;

        int index = inventory.GetInventory().IndexOf(this);

        inventory.RemoveItemIndex(index);
    }

    internal void ShowDetails()
    {
       DefaultCommands();

        Console.WriteLine($"\n--- {Name} ---");
        ItemDescription();

        // Display options
        var keys = CommandActions.Keys.ToList();
        for (int i = 0; i < keys.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {keys[i]}");
        }
        Console.WriteLine();
        Console.WriteLine("[0] Back");
        int choice = InputHelper.GetIntInput() - 1;
        if (choice >= 0 && choice < keys.Count)
        {
            CommandActions[keys[choice]]?.Invoke();
        }
        
    }
}
