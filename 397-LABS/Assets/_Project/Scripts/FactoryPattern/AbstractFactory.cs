using UnityEngine;
using System.Collections.Generic;
using KBCore.Refs;

namespace Platformer397
{
    public abstract class AbstractFactory : MonoBehaviour
    {
        public List<GameObject> agentPrefabs;
        [Child(Flag.ExcludeSelf)] public Transform spawnLocation;
        public Transform spawnTarget;

        public abstract void GenerateAgent();
    }
}
