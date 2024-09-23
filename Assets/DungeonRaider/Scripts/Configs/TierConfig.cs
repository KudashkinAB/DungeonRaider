using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DR/Tiers")]
public class TierConfig : ScriptableObject
{
    [SerializeField] private List<Tier> _tiers;

    public Tier GetTier(int level)
    {
        return _tiers[level];
    }
}

[System.Serializable]
public class Tier
{
    [SerializeField] private string _name = "TierName";
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private float _minStatModifier = 0;
    [SerializeField] private float _maxStatModifier = 0.05f;
    [SerializeField] private float _enchantChance = 0.1f;
    [SerializeField] private float _minEnchantPower = 0.01f;
    [SerializeField] private float _maxEnchantPower = 0.1f;

    public string Name => _name;
    public Color Color => _color;
    public float MinStatModifier => _minStatModifier;
    public float MaxStatModifier => _maxStatModifier;
    public float EnchantChance => _enchantChance;
    public float MinEnchantPower => _minEnchantPower;
    public float MaxEnchantPower => _maxEnchantPower;
}
