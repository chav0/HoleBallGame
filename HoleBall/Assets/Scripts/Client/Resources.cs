using System;
using Client.Objects;
using UnityEngine;

namespace Client
{
    [CreateAssetMenu(fileName = "Resources", menuName = "Settings/Resources")]
    public class Resources : ScriptableObject
    {
        public WorldPrefab[] Worlds; 
    }

    [Serializable]
    public class WorldPrefab
    {
        public WorldObject WorldObject;
        public int WorldId; 
    }
}
