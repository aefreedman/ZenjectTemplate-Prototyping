using System;
using SecretCrush.Zenject;
using SpaceGameOne;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball
{
    public class BallInstaller : MonoInstaller<BallInstaller>
    {
        [InjectOptional] private ObjectTunables _settingsOverride = null; // required for default tunable override below
        [SerializeField] private Settings _settings = null;
        [SerializeField] private BallTunables _ballTunables = null;

        public override void InstallBindings()
        {
            // This allows you to override the default settings in the installer with a different ObjectTunables object
            // that you can create at runtime
            Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            // Cast your init state enum into an int so the StateManager doesn't complain
            _settings.DefaultSettings.InitState = (int) _settings.InitState;

            Container.BindInstance(_ballTunables);

            Container.Bind<BallModel>().AsSingle();
            Container.Bind<ObjectModel>().To<BallModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallStateFactory>().AsSingle();
            Container.Bind<ObjectStateFactory>().To<BallStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectStateManager>().AsSingle();
            Container.BindInterfacesTo<ObjectStateCommon>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public BallState InitState;
            public ObjectTunables DefaultSettings;
        }

        [Serializable]
        public class BallTunables
        {
            public float PushForceScale;
            public float PushForceMax;
            public int BaseScore;
        }
    }
}