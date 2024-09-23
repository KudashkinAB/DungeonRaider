using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DR/GameConfig")]
public class GameConfig: ScriptableObject
{
    [SerializeField] private TierConfig _tierConfig;
    [SerializeField] private LevelingConfig _levelingConfig;
    [SerializeField] private ItemsConfig _itemsConfig;
    [SerializeField] private LootingConfig _lootingConfig;
    [SerializeField] private ResourceConfig _resourceConfig;

    public TierConfig TierConfig => _tierConfig;
    public LevelingConfig LevelingConfig => _levelingConfig;
    public ItemsConfig ItemsConfig => _itemsConfig;
    public LootingConfig LootingConfig => _lootingConfig;
    public ResourceConfig ResourceConfig => _resourceConfig;
}
