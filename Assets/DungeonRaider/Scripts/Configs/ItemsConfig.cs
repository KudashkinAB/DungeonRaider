using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DR/ItemsConfig")]
public class ItemsConfig : ScriptableObject
{
    [SerializeField] private ItemData[] _items;

    public Sprite GetSprite(Item item)
    {
        return GetItemData(item.ItemType).GetSprite(item.Tier);
    }

    public string GetItemName(Item item)
    {
        return GetItemData(item.ItemType).ItemName;
    }

    public ItemData GetItemData(ItemType itemType)
    {
        foreach (var itemData in _items)
        {
            if (itemData.ItemType == itemType)
            {
                return itemData;
            }
        }
        Debug.LogError("Missing item type config!");
        return null;
    }
}

[System.Serializable]
public class ItemData
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private List<StatDelta> _statsDelta;

    public ItemType ItemType => _itemType;
    public string ItemName => _itemName;
    public List<StatDelta> StatsDelta => _statsDelta;

    public Sprite GetSprite(int tier)
    {
        return _sprites[tier];
    }

    public float GetStartStat(Stat stat, int level)
    {
        foreach (var delta in _statsDelta) 
        {
            if(delta.Stat == stat)
                return delta.StartValue + delta.LevelDelta * level;    
        }
        return 0f;
    }
}

[System.Serializable]
public class StatDelta
{
    [SerializeField] private Stat _stat;
    [SerializeField] private float _startValue = 0;
    [SerializeField] private float _levelDelta = 0;

    public Stat Stat => _stat;
    public float StartValue => _startValue;
    public float LevelDelta => _levelDelta;
}
