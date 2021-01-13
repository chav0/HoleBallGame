using System;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;

namespace Client.Objects
{
    public class SplineTrackObject : MonoBehaviour
    {
        public SplineComputer Spline;
        public float TrackingDuration;

        public void StartTracking(GameObject go, float start, float end)
        {
            var currentValue = start;
            DOTween.Sequence().AppendCallback(() => go.GetComponent<Rigidbody>().isKinematic = true).
                Append(DOTween.To(value =>
                    {
                        currentValue = value;
                        go.transform.position = Spline.EvaluatePosition(value);
                    }, start, end, TrackingDuration))
                .AppendCallback(() => go.GetComponent<Rigidbody>().isKinematic = false).SetEase(Ease.InCubic);
        }
    }
}