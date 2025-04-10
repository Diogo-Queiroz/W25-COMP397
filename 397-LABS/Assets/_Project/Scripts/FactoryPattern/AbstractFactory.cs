using UnityEngine;
using System.Collections.Generic;

//namespace Platformer397
namespace Platformer397 {

    //AbstractFactory Class
    public abstract class AbstractFactory : MonoBehaviour {

        public List<GameObject> agentPrefabs;
        public Transform spawnLocation;
        public Transform spawnTarget;

        public abstract void GenerateAgent();


        } //End of AbstractFactory Class

} //End of namespace Platformer397
