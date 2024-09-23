using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class LootingSystem
{
    [Inject] private GameData _gameData;
    [Inject] private GameConfig _gameConfig;
    [Inject] private ResourceController _resourceController;
    [Inject] private LevelingController _levelingController;

    private Queue<Item> _items = new Queue<Item>();

    public System.Action OnItemChanged;

    public Item CurrentItem => _items.Peek();

    public bool TryGetCurrentItem(out Item item)
    {
        return _items.TryPeek(out item);
    }

    public bool HasItems => _items.Count > 0;

    private void RemoveCurrent() 
    {
        _items.Dequeue();
        OnItemChanged?.Invoke();
    }

    public void EqipCurrent()
    {
        if (HasItems == false)
            return;
        _gameData.PlayerCharacter.Inventory.EqipItem(CurrentItem);
        RemoveCurrent();
    }

    public void SellCurrent()
    {
        if(HasItems == false) 
            return;
        _resourceController.AddResource(Resource.Money, _gameConfig.ResourceConfig.SellCost);
        RemoveCurrent();
    } 

    public bool TryToLoot()
    {
        if(_resourceController.TrySpendResource(Resource.Keys, _gameConfig.ResourceConfig.LootCost))
        {
            _items.Enqueue(GenerateItem(_gameData.PlayerCharacter, _gameConfig.LootingConfig.GetLootLevel(_gameData.LootLevel)));
            _levelingController.AddXp(_gameConfig.ResourceConfig.LootXP);
            OnItemChanged?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }

    private Item GenerateItem(Creature creature, LootLevel lootLevel)
    {
        Item generatedItem = new Item(GenerateItemType(), creature.Level, GenerateTier(lootLevel));
        Tier tier = _gameConfig.TierConfig.GetTier(generatedItem.Tier);
        RandomizeByTier(generatedItem, tier);
        Enchant(generatedItem, tier);
        Debug.Log($"[Looting] generated item: {generatedItem.ItemType} {generatedItem.Level} {generatedItem.Tier}");
        return generatedItem;
    }

    private ItemType GenerateItemType()
    {
        return (ItemType)(Random.Range(0, System.Enum.GetNames(typeof(ItemType)).Length));
    }

    private int GenerateTier(LootLevel lootLevel)
    {
        return lootLevel.GenerateTier();
    }

    private void RandomizeByTier(Item item, Tier tier)
    {
        foreach (var delta in _gameConfig.ItemsConfig.GetItemData(item.ItemType).StatsDelta)
        {
            float initValue = delta.StartValue + item.Level * delta.LevelDelta;
            if (initValue > 0)
                item.Stats.Set(delta.Stat, initValue * Random.Range(tier.MinStatModifier, tier.MaxStatModifier));
        }
    }

    private void Enchant(Item item, Tier tier)
    {
        if(Random.Range(0f, 1f) < tier.EnchantChance)
            item.Stats.Set(Stats.Enchants[Random.Range(0, Stats.Enchants.Count)], Random.Range(tier.MinEnchantPower, tier.MaxEnchantPower));
    }
}
