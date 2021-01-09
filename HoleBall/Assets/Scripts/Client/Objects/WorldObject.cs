using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Client.Objects
{
    public class WorldObject : MonoBehaviour
    {
        public BallObject[] Balls;
        public GameObject Flag; 
    }
}
