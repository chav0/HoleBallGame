using System;
using UnityEngine;

namespace Client.Objects
{
    public class BallObject : MonoBehaviour
    {
        public Transform SpawnPoint; 
        public Rigidbody Rigidbody; 
        public bool BallInTheHole { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            var door = other.GetComponent<DoorObject>();
            if (door != null)
                door.Count++; 
        }
        
        private void OnTriggerExit(Collider other)
        {
            var door = other.GetComponent<DoorObject>();
            if (door != null)
                door.Count--; 
        }

        private void OnTriggerStay(Collider other)
        {
            var endObject = other.GetComponent<EndObject>();
            if (endObject != null)
            {
                BallInTheHole = true;
                Rigidbody.velocity *= 0.95f; 
            }
            
            var fanObject = other.GetComponent<FanObject>();
            if (fanObject != null)
            {
                var fanTransform = fanObject.gameObject.transform;
                var velocity = Rigidbody.velocity;
                var forward = fanTransform.forward.normalized;
                //an attempt to improve the movement of the ball
                Rigidbody.AddForce(forward*fanObject.Force*Time.fixedDeltaTime);
                // var otherDirection = Vector3.one - new Vector3(Mathf.Abs(forward.x), Mathf.Abs(forward.y), Mathf.Abs(forward.z));
                // Rigidbody.velocity = forward * fanObject.Force + new Vector3(velocity.x * otherDirection.x, velocity.y * otherDirection.y, velocity.z * 
                // otherDirection.z) * fanObject.Deceleration; 
            }
            
            var acceleratorObject = other.GetComponent<AcceleratorObject>();
            if (acceleratorObject != null)
            {
                var velocityValue = Rigidbody.velocity.magnitude * 1.1f; 
                Rigidbody.velocity = acceleratorObject.transform.forward * velocityValue; 
            }
            
            var speedObject = other.GetComponent<SpeedObject>();
            if (speedObject != null)
            {
                //created unnatural ball's behaviour
                // if (speedObject.Speed > 0f)
                //     Rigidbody.velocity = Rigidbody.velocity.normalized * speedObject.Speed;
            }
        }
    }
}