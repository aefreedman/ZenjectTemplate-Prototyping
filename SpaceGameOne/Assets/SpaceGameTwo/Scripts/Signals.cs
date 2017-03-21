using System;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo
{
    public class Signals
    {
        public class SpawnNewBall : Signal<float, SpawnNewBall> {}

        public class ScorePoints : Signal<int, ScorePoints> {}

        public class BallTriggerExit : Signal<Collider2D, Guid, BallTriggerExit> { }
    }
}