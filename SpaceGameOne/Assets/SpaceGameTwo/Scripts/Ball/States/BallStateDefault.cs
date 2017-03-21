using SecretCrush.Zenject;

namespace SpaceGameTwo.Ball.States
{
    public class BallStateDefault : IObjectState
    {
        private readonly BallModel _model;


        public BallStateDefault(BallInstaller.BallTunables tunables, BallModel model)
        {
            _model = model;
        }


        public void Dispose() {}

        public void Initialize()
        {
           //model.Rigidbody2D.isKinematic = true;
        }

        public void Update() {}

        public void LateUpdate() {}

        public void FixedUpdate() {}
    }
}