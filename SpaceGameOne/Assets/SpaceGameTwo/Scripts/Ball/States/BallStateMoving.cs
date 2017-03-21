using System.Linq;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball.States
{
    public class BallStateMoving : IObjectState
    {
        private readonly BallModel _model;
        private readonly BallFacade _facade;
        private readonly SpriteRenderer _sprite;
        [Inject] private ObjectStateManager _stateManager;
        private readonly Signals.ScorePoints _scorePointsSignal;
        private readonly int _scoreValue;

        public BallStateMoving(
            BallModel model,
            BallFacade facade,
            Signals.ScorePoints score,
            BallInstaller.BallTunables tunables,
            SpriteRenderer sprite)
        {
            _model = model;
            _facade = facade;
            _scoreValue = tunables.BaseScore;
            _scorePointsSignal = score;
            _sprite = sprite;
        }


        public void Dispose() {}

        public void Initialize() {}

        public void Update() {}

        public void LateUpdate() {}

        public void FixedUpdate()
        {
            if (_model.Rigidbody2D.velocity.sqrMagnitude < 0.01f)
            {
                if (_facade.TriggerGameObjects.Any(element => element.name.Contains("Goal")))
                {
                    Debug.Log("goal!");
                    _sprite.color = new Color(0, 1f, 1f);
                    _stateManager.ChangeState((int) BallState.Scored, null);
                    _scorePointsSignal.Fire(_scoreValue);
                }
            }
        }
    }
}