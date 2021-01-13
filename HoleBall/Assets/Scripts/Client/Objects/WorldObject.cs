using System;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Client.Objects
{
    public class WorldObject : MonoBehaviour
    {
        public BallObject[] Balls;
        public GameObject Flag;

        private void Awake()
        {
            Balls = GameObject.FindGameObjectsWithTag("Ball").Select(x => x.GetComponent<BallObject>()).ToArray();
            var targetGroup = FindObjectOfType<CinemachineTargetGroup>();
            if (targetGroup)
            {
                targetGroup.m_Targets = Balls.Select(x =>
                {
                    return new CinemachineTargetGroup.Target() {radius = 3, target = x.transform, weight = 1};
                }).ToArray();
            }
        }
    }
}
