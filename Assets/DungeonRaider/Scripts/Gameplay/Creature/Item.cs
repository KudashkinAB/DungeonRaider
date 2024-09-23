using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected ItemType _itemType;
    protected int _level;
    protected Stats _stats;
    protected int _tier;

    public ItemType ItemType => _itemType;
    public int Level => _level;
    public Stats Stats => _stats;
    public int Tier => _tier;

    public Item(ItemType itemType, int level, int tier)
    {
        _itemType = itemType;
        _level = level;
        _tier = tier;
        _stats = new Stats();
    }
}
