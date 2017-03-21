using SecretCrush.Zenject;
using SpaceGameTwo.Ball;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo
{
    public class GameController : MonoBehaviour
    {
        [Inject(Id = "BallSpawner")] private ObjectSpawner _ballSpawner;

        public void Start()
        {
            var b = (BallSpawner) _ballSpawner;
            b.SpawnBall();
        }
    }
}