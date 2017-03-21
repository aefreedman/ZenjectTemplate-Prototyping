using System;
using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameTwo.Ball.States
{
    public class BallStateScored : IObjectState
    {
        private readonly int _pointValue;
        private readonly Signals.BallTriggerExit _ballTriggerExitSignal;
        private readonly Signals.ScorePoints _scorePointsSignal;
        private readonly ObjectStateManager _stateManager;
        private readonly Guid _guid;
        private readonly SpriteRenderer _sprite;

        private BallStateScored(
            BallInstaller.BallTunables tunables,
            Signals.BallTriggerExit ballTriggerExit,
            Signals.ScorePoints scorePoints,
            ObjectStateManager stateManager,
            BallFacade facade,
            SpriteRenderer sprite
            )
        {
            _pointValue = tunables.BaseScore;
            _ballTriggerExitSignal = ballTriggerExit;
            _ballTriggerExitSignal += OnTriggerExit;

            _scorePointsSignal = scorePoints;
            _stateManager = stateManager;
            _guid = facade.Guid;

            _sprite = sprite;
        }


        public void Initialize() {}

        public void Update() {}

        public void LateUpdate() {}

        public void FixedUpdate() {}

        public void Dispose() {}

        private void OnTriggerExit(Collider2D collider, Guid guid)
        {
            if (guid != _guid) return;
            if (collider.name.Contains("Goal"))
            {
                _scorePointsSignal.Fire(-_pointValue);
                _sprite.color = new Color(1f, 0f, 0.1f);
                _stateManager.ChangeState((int) BallState.DefaultState, null);
            }
        }
    }
}