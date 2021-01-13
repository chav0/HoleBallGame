using UnityEngine;

namespace Client.Objects
{
    public class SplineTrackEnter : MonoBehaviour
    {
        public float Start;
        public float End;
        public SplineTrackObject SplineTrackObject;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BallObject>())
            {
                SplineTrackObject.StartTracking(other.gameObject, Start, End);
            }
        }
    }
}