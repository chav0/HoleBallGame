using System;
using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class ButtonObject : MonoBehaviour
    {
        public GameObject Target;
        public Transform Button;
        
        private bool _enabled;
        private float _startPosition;

        private void Awake()
        {
            _startPosition = Button.localPosition.x;
        }

        private void OnTriggerEnter(Collider other)
        {
            var ballObject = other.GetComponent<BallObject>();
            if(_enabled || !ballObject)
                return;
            Switch();
            if (Target != null)
            {
                var buttonControllable = Target.GetComponent<IButtonControllable>();
                buttonControllable?.SetEnabled(enabled);
            }
        }

        private void Switch()
        {
            _enabled = !_enabled;
            Button.DOLocalMoveX(_enabled ? _startPosition - 0.14f : _startPosition, 0.3f).SetEase(Ease.OutBack);
        }

        [ContextMenu("Test")]
        private void Test()
        {
            Switch();
        }
    }
}