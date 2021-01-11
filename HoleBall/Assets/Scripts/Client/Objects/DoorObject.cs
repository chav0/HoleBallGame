using System;
using DG.Tweening;
using UnityEngine;

namespace Client.Objects
{
    public class DoorObject : MonoBehaviour, IButtonControllable
    {
        [SerializeField] private Transform _door1; 
        [SerializeField] private Transform _door2;
        [SerializeField] private int _minBalls;
        [SerializeField] private float _timeToClose;
        [SerializeField] private float _timeToOpen;

        public int Count { get; set; }
        private Sequence _sequence;

        private void Update()
        {
            if(Count >= _minBalls)
                Open();
        }
        
        private void Open()
        {
            if(_sequence != null && _sequence.IsPlaying())
                return;


            _door1.eulerAngles = new Vector3(0f, 0f, 0f);
            _door2.eulerAngles = new Vector3(0f, 0f, 180f); 
            
            _sequence?.Kill();
            _sequence = DOTween.Sequence()
                .Append(_door1.DOLocalRotate(new Vector3(0f, 0f, 90f), _timeToOpen))
                .Join(_door2.DOLocalRotate(new Vector3(0f, 0f, 90f), _timeToOpen))
                .AppendInterval(_timeToClose)
                .Append(_door1.DOLocalRotate(new Vector3(0f, 0f, 0f), _timeToOpen))
                .Join(_door2.DOLocalRotate(new Vector3(0f, 0f, 180f), _timeToOpen)); 
        }

        public void SetEnabled(bool enable)
        {
            Open();
        }
    }
}