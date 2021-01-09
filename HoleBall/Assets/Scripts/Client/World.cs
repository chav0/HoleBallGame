using System;
using System.Linq;
using Client.Objects;
using UnityEngine;

namespace Client
{
    public sealed class World : IDisposable
    {
        private readonly WorldObject _worldObject;

        public bool BallInTheHole => _worldObject.Balls.Any(ball => ball.BallInTheHole);
        public int WorldId { get; }

        public World(WorldObject worldObject, int worldId)
        {
            _worldObject = worldObject;
            WorldId = worldId; 
        }

        public void Start()
        {
            foreach (var ball in _worldObject.Balls)
            {
                ball.Rigidbody.useGravity = true; 
                ball.Rigidbody.freezeRotation = false;
            }
        }

        public void Restart()
        {
            foreach (var ball in _worldObject.Balls)
            {
                ball.transform.position = ball.SpawnPoint.position;
                ball.Rigidbody.useGravity = false; 
                ball.Rigidbody.velocity = Vector3.zero;
                ball.Rigidbody.freezeRotation = true;
            }
        }

        public void SetWin()
        {
            _worldObject.Flag.SetActive(true);
        }
        
        public void Dispose()
        {
        }
    }
}
