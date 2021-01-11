using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class WaySwitcherObject : MonoBehaviour
    {
        public Quaternion ALocalRotation;
        public Quaternion BLocalRotation;
        public HingeJoint HingeJoint;

        private void OnMouseDown()
        {
            Switch();
        }
        
        private void Switch()
        {
            var motor = HingeJoint.motor;
            motor.targetVelocity = -motor.targetVelocity;
            HingeJoint.motor = motor;
        }
        
    }
}