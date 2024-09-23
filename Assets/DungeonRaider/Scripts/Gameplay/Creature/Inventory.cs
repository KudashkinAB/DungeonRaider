using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    protected Dictionary<ItemType, Item> _items = new Dictionary<ItemType, Item>();

    public List<Item> ItemsList => _items.Values.ToList();

    public System.Action<ItemType> OnItemChanged;

    public bool TryGetItem(ItemType itemType, out Item item)
    {
        return _items.TryGetValue(itemType, out item);
    }

    public bool ContainsItem(ItemType itemType)
    {
        return _items.ContainsKey(itemType);
    }

    public bool EqipItem(Item item) 
    {
        if (_items.ContainsKey(item.ItemType))
        {
            _items[item.ItemType] = item;
            OnItemChanged?.Invoke(item.ItemType);
            return true;
        }
        else
        {
            _items.Add(item.ItemType, item);
            OnItemChanged?.Invoke(item.ItemType);
            return false;
        }
    }
}
