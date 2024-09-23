using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameData
{
    private Creature _playerCharacter;
    private int _lootLevel = 1;

    public int Expirience = 0;
    public PlayerResourcesData PlayerResources;

    public Creature PlayerCharacter => _playerCharacter;
    public int LootLevel => _lootLevel;

    [Inject]
    private void Construct()
    {
        _playerCharacter = new Creature(new Stats());
        PlayerResources = new PlayerResourcesData();
        Debug.Log("Init GameData");
    }
}
