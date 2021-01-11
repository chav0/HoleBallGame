using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class GateObject : MonoBehaviour
    {
        public Transform Left;
        public Transform Right;
        private bool _opened;
        private void OnMouseDown()
        {
            _opened = !_opened;
            Left.DOScaleX(_opened ? 0.1f : 1, 0.3f).SetEase(Ease.OutBack);
            Right.DOScaleX(_opened ? 0.1f : 1, 0.3f).SetEase(Ease.OutBack);
        }

        [ContextMenu("Test")]
        private void Test()
        {
            OnMouseDown();
        }
    }
}