using UnityEngine;

namespace Client.Objects
{
    public class SpringObject : MonoBehaviour
    {
        public Collider Collider;
        public PhysicMaterial Material;

        private void OnEnable()
        {
            Material.bounciness = 0.8f;
            Collider.material = Material; 
        }
    }
}