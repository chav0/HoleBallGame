using System;
using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class FigureObject : MonoBehaviour
    {
        private Sequence _sequence; 
        private void OnMouseDown()
        {
            if(_sequence != null && _sequence.IsPlaying())
                return;
            
            _sequence?.Kill();
            _sequence = DOTween.Sequence()
                .Append(transform.DOLocalRotate(transform.eulerAngles + new Vector3(0f, 90f, 0f), 0.5f).SetEase(Ease.OutBack));
        }

        private void OnDestroy()
        {
            _sequence?.Kill(); 
        }
    }
}