using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
internal abstract class Item : MonoBehaviour
{
    internal string Name;

    protected Vector2Int Die;

    [SerializeField] protected ItemStats Stats;

    public int ActionPointCost { get; protected set; }
    
    private void Awake()
    {
        Die = Stats.ItemRollRange;
        ActionPointCost = Stats.ActionPointCost;
        Name = Stats.ThisItemName;
    }

    //allows looping through methods
    protected Dictionary<string, Action> CommandActions = new();

    protected virtual void DefaultCommands()
    {
     
        CommandActions["Drop"] = Drop;
       
    }

    internal abstract void Use();
    protected string ItemDescription()
    {
        return Stats.Description;
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
        Console.WriteLine($"Are you sure you want to get rid of {Name}?");
        Console.WriteLine("[1] Keep");
        Console.WriteLine("[2] Drop");
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
