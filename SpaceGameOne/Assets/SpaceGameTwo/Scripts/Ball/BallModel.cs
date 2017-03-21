using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball
{
    public class BallModel : ObjectModel
    {

        [Inject] public Transform Transform;
        [Inject] public Rigidbody2D Rigidbody2D;

        public BallModel(ObjectTunables settings, ObjectStateManager stateManager)
            : base(settings, stateManager)
        {
            

        }
    }
}