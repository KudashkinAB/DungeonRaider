using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    public Stats Stats;
    protected int _level = 1;

    public System.Action OnStatsChanged;

    public Creature(Stats stats)
    {
        Stats = stats;
        _inventory = new Inventory();
        _inventory.OnItemChanged += OnItemChanged;
    }

    protected Inventory _inventory;

    public Inventory Inventory => _inventory;
    public int Level => _level;

    public void SetLevel(int level)
    {
        _level = level;
    }

    public void UpdateStats()
    {
        Stats.Clear();
        foreach (var item in _inventory.ItemsList)
        {
            Stats.Add(item.Stats);
        }
        OnStatsChanged?.Invoke();
    }

    private void OnItemChanged(ItemType itemType) 
    {
        UpdateStats();
    }
}
