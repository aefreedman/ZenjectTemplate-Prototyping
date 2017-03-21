using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball
{
    public class BallSpawner : ObjectSpawner, ITickable
    {
        private readonly Settings _settings;
        private readonly Signals.SpawnNewBall _spawnNewBallSignal;

        private float _delayTimer;
        private bool _spawn;

        public BallSpawner(
            ObjectGlobalTunables globalTunables,
            ObjectRegistry registry,
            BallFacade.Factory factory,
            Settings settings,
            Signals.SpawnNewBall spawnNewBall)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
            _spawnNewBallSignal = spawnNewBall;
            _spawnNewBallSignal += SpawnWithDelay;
        }

        public void Tick()
        {
            if (_delayTimer > 0)
                _delayTimer -= Time.deltaTime;
            else
            {
                if (_spawn)
                {
                    SpawnBall();
                    _spawn = false;
                }
            }
        }

        private void Dispose() {}

        public void SpawnBall()
        {
            SpawnBall(BallState.AwaitingInput);
        }

        public void SpawnBall(BallState initState)
        {
            var t = new ObjectTunables {InitState = (int) initState};
            var f = ObjectFactory.Create(t);
            var m = (BallModel) f.Model;
            f.gameObject.SetActive(true);
            m.Rigidbody2D.position = _settings.SpawnLocation;
        }

        public void SpawnWithDelay(float delay)
        {
            _spawn = true;
            _delayTimer = delay;
        }

        [Serializable]
        public class Settings
        {
            public Vector2 SpawnLocation;
            public BallState BallState;
        }
    }
}