using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConfigInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        base.InstallBindings();

        Container.BindInstances(_gameConfig);
    }
}
