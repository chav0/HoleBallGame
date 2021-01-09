using System;
using System.Collections.Generic;
using System.Linq;
using Client.Objects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client.Scene
{
    public class UnityScene : IDisposable
    {
        private readonly Resources _resources;
        private readonly List<GameObject> _createdObjects = new List<GameObject>();
        
        public UnityScene(Resources resources)
        {
            _resources = resources;
        }

        public WorldObject CreateWorldObject(int worldId)
        {
            var prefab = _resources.Worlds.FirstOrDefault(x => x.WorldId == worldId);
            if (prefab == null) 
                return null;
            
            var world = Object.Instantiate(prefab.WorldObject);
            _createdObjects.Add(world.gameObject);
            return world;

        }

        public void Dispose()
        {
            foreach (var go in _createdObjects)
            {
                Object.Destroy(go);
            }
        }
    }
}