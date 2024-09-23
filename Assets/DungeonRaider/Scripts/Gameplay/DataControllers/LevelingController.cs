using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelingController
{
    [Inject] private GameData _gameData;
    [Inject] private GameConfig _gameConfig;
    [Inject] private ResourceController _resourceController;

    public System.Action<int> OnXpChanged;

    public int ReqiredXp => _gameConfig.LevelingConfig.GetXpReqirement(_gameData.PlayerCharacter.Level);
    public int CurrentXp => _gameData.Expirience;
    public int CurrentLevel => _gameData.PlayerCharacter.Level;

    public void AddXp(int xp)
    {
        _gameData.Expirience += xp;
        Debug.Log($"[Leveling] AddXp {xp} : {_gameData.Expirience} / {ReqiredXp}" );
        while(_gameData.Expirience >= ReqiredXp)
        {
            _gameData.Expirience -= ReqiredXp;
            LevelUp();
        }
        OnXpChanged?.Invoke(_gameData.Expirience);
    }

    public void LevelUp()
    {
        _gameData.PlayerCharacter.SetLevel(_gameData.PlayerCharacter.Level + 1);
        _resourceController.AddResource(Resource.Keys, _gameConfig.ResourceConfig.KeysPerLevel);
        Debug.Log("[Leveling] LevelUp");
    }
}
