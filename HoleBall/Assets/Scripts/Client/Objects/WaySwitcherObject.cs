using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class WaySwitcherObject : MonoBehaviour
    {
        public Quaternion ALocalRotation;
        public Quaternion BLocalRotation;
        public Rigidbody Object;
        private bool _enabled;

        private void OnMouseDown()
        {
            Switch();
        }
        
        private void Switch()
        {
            _enabled = !_enabled;
            Object.DORotate(_enabled ? ALocalRotation.eulerAngles : BLocalRotation.eulerAngles, 0.2f)
                .SetEase(Ease.OutExpo);
        }
        
    }
}