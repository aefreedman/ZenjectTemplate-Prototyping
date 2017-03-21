using System;
using SecretCrush.Zenject;
using SpaceGameTwo.Ball;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Installers
{
    public class SpaceGameTwoInstaller : MonoInstaller<SpaceGameTwoInstaller>
    {
        [Inject] private readonly Settings _settings = null;


        public override void InstallBindings()
        {
            Container.Bind<SignalManager>().AsSingle();
            Container.DeclareSignal<Signals.SpawnNewBall>();
            Container.DeclareSignal<Signals.ScorePoints>();
            Container.DeclareSignal<Signals.BallTriggerExit>();

            Container.Bind<ObjectRegistry>().AsSingle();

            Container.BindFactory<ObjectTunables, ObjectFacade, BallFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<BallInstaller>(_settings.BallPrefab)
                .UnderTransformGroup("Balls");
            Container.Bind<ObjectSpawner>().WithId("BallSpawner").To<BallSpawner>().AsSingle();
            Container.BindInterfacesTo<BallSpawner>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public GameObject BallPrefab;

            public float SpawnDelay = 0.125f;
        }
    }
}