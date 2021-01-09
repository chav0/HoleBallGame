using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class FanAnimation : MonoBehaviour
    {
        private Sequence _sequence;

        private void OnEnable()
        {
            _sequence?.Kill();
            var localEulerAngles = transform.localEulerAngles;
            _sequence = DOTween.Sequence()
                .Append(transform.DOLocalRotate(new Vector3(localEulerAngles.x, 180f, localEulerAngles.z), 1f).SetEase(Ease.Linear))
                .Append(transform.DOLocalRotate(new Vector3(localEulerAngles.x, 360f, localEulerAngles.z), 1f).SetEase(Ease.Linear))
                .AppendCallback(() => transform.localEulerAngles = Vector3.zero)
                .SetLoops(-1);
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}