using System;
using ModestTree;
using SecretCrush.Zenject;
using SpaceGameOne.States;
using SpaceGameTwo.Ball.States;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball
{
    public enum BallState 
    {
        // The first state must always be a "blank" state 
        // The second state will be the default init state
        None,
        DefaultState,
        AwaitingInput,
        Moving,
        Scored
    }

    public class BallStateFactory : ObjectStateFactory
    {
        public BallStateFactory(DiContainer container)
            : base(container) {}

        public override void Validate()
        {
            Assert.That(Application.isEditor);

            foreach (var state in new[] { BallState.DefaultState })
                Create((int) state);
        }

        public override IObjectState Create(int state, object[] extraArgs = null)
        {
            var ballStates = (BallState) state;
            switch (ballStates)
            {
                case BallState.DefaultState:
                    return Container.Instantiate<BallStateDefault>();
                case BallState.None:
                    break;
                case BallState.AwaitingInput:
                    return Container.Instantiate<BallStateAwaitingInput>();
                case BallState.Moving:
                    return Container.Instantiate<BallStateMoving>();
                case BallState.Scored:
                    return Container.Instantiate<BallStateScored>();
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }

            throw Assert.CreateException();
        }

        public IObjectState Create(BallState state, object[] extraArgs = null)
        {
            return Create((int) state, extraArgs);
        }
    }
}