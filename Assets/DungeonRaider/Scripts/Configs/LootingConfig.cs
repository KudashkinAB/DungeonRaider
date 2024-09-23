using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DR/LootingConfig")]
public class LootingConfig : ScriptableObject
{
    [SerializeField] private LootLevel[] _lootLevels;

    public LootLevel GetLootLevel(int lootLevel)
    {
        if(lootLevel >= _lootLevels.Length)
        {
            return _lootLevels[_lootLevels.Length - 1];
        }
        return _lootLevels[lootLevel];
    }
}

[System.Serializable]
public class LootLevel
{
    [SerializeField] private float[] _tierWeigths;

    public int GenerateTier()
    {
        float sum = 0;
        foreach(var tier in _tierWeigths)
        {
            sum += tier;
        }
        float randomized = Random.Range(0f, sum);
        for (int i = 0; i < _tierWeigths.Length; i++)
        {
            randomized -= _tierWeigths[i];
            if (randomized <= 0)
                return i;
        }
        Debug.LogError("Missing tier, return 0");
        return 0;
    }
}
