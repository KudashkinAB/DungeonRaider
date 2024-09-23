using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameCoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Data
        Container.BindInterfacesAndSelfTo<GameData>().AsSingle().NonLazy();
        //Controllers
        Container.BindInterfacesAndSelfTo<ResourceController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<LevelingController>().AsSingle().NonLazy();
        //Systems
        Container.BindInterfacesAndSelfTo<LootingSystem>().AsSingle().NonLazy();
    }
}
