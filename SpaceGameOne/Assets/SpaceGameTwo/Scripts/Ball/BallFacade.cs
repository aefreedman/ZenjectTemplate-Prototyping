using System;
using System.Collections.Generic;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameTwo.Ball
{
    public class BallFacade : ObjectFacade
    {
        public List<GameObject> TriggerGameObjects;
        [Inject] private Signals.BallTriggerExit _ballTriggerExitSignal;
        public Guid Guid { get; private set; }

        public void Start()
        {
            TriggerGameObjects = new List<GameObject>();
            Guid = Guid.NewGuid();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerGameObjects.Remove(collision.gameObject);
            _ballTriggerExitSignal.Fire(collision, Guid);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerGameObjects.Add(collision.gameObject);
        }


        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}