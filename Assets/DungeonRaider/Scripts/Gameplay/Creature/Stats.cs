using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    private Dictionary<Stat, float> _statValues = new Dictionary<Stat, float>();

    public static readonly List<Stat> BaseStats = new List<Stat>() { Stat.HP, Stat.STR, Stat.DEF, Stat.AGI };
    public static readonly List<Stat> AllStats = new List<Stat>() { Stat.HP, Stat.STR, Stat.DEF, Stat.AGI, Stat.DodgeChance, Stat.CritChance, Stat.Vampirism };
    public static readonly List<Stat> Enchants = new List<Stat>() { Stat.DodgeChance, Stat.Vampirism, Stat.CritChance };

    public float Get(Stat stat)
    {
        return _statValues.ContainsKey(stat) ? _statValues[stat] : 0;
    }

    public void Set(Stat stat, float value)
    {
        _statValues[stat] = value;
    }

    public void Clear()
    {
        _statValues.Clear();
    }

    public void Add(Stats add)
    {
        foreach(var stat in add._statValues)
        {
            if (_statValues.ContainsKey(stat.Key))
                _statValues[stat.Key] += stat.Value;
            else
                _statValues.Add(stat.Key, stat.Value);
        }
    }
}

public enum Stat
{
    HP, STR, DEF, AGI, Vampirism, CritChance, DodgeChance
}
