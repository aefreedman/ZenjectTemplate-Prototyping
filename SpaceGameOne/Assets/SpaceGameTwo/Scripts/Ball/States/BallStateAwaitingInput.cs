using SecretCrush.Zenject;
using SpaceGameTwo.Installers;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball.States
{
    public class BallStateAwaitingInput : IObjectState
    {
        private readonly float _forceScale;
        private readonly float _forceMax;
        private readonly float _spawnDelay;
        [Inject] private BallModel _model;
        [Inject] private LineRenderer _lineRenderer;
        [Inject] private ObjectStateManager _stateManager;
        [Inject] private Signals.SpawnNewBall _spawnNewBallSignal;

        public BallStateAwaitingInput(BallInstaller.BallTunables tunables, SpaceGameTwoInstaller.Settings gameSettings)
        {
            _forceScale = tunables.PushForceScale;
            _forceMax = tunables.PushForceMax;
            _spawnDelay = gameSettings.SpawnDelay;
        }

        public void Dispose() {}

        public void Initialize()
        {
            _lineRenderer.enabled = false;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lineRenderer.enabled = true;
                _lineRenderer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }


            if (Input.GetMouseButton(0)) {}

            if (Input.GetMouseButtonUp(0))
            {
                var dir = _lineRenderer.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dir.z = 0;

                _model.Rigidbody2D.AddForce(Vector2.ClampMagnitude(dir * _forceScale, _forceMax));

                _lineRenderer.enabled = false;

                _stateManager.ChangeState((int) BallState.Moving, null);
                _spawnNewBallSignal.Fire(_spawnDelay);
            }
        }

        public void LateUpdate() {}

        public void FixedUpdate() {}
    }
}