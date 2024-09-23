using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        Container.BindInstances(_gameConfig);
    }
}