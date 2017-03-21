using SecretCrush.Zenject;
using SpaceGameTwo.Ball;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Installers
{
    [CreateAssetMenu(fileName = "SpaceGameTwoSettingsInstaller", menuName = "Installers/SpaceGameTwoSettingsInstaller")]
    public class SpaceGameTwoSettingsInstaller : ScriptableObjectInstaller<SpaceGameTwoSettingsInstaller>
    {

        public SpaceGameTwoInstaller.Settings GameSettings;
        public ObjectGlobalTunables ObjectGlobalTunables;
        public BallSpawner.Settings BallSpawnerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(GameSettings);
            Container.BindInstance(ObjectGlobalTunables);
            Container.BindInstance(BallSpawnerSettings);
        }
    }
}