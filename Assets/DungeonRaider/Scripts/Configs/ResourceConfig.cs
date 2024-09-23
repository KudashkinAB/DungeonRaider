using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DR/ResourceConfig")]
public class ResourceConfig : ScriptableObject
{
    [SerializeField] private int _lootCost = 1;
    [SerializeField] private int _sellCost = 10;
    [SerializeField] private int _keysPerLevel = 200;
    [SerializeField] private int _lootXP = 10;

    public int LootCost => _lootCost;
    public int SellCost => _sellCost;
    public int KeysPerLevel => _keysPerLevel;
    public int LootXP => _lootXP;
}
