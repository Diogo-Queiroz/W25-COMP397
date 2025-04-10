using UnityEngine;
using UnityEngine.AI;
using KBCore.Refs;

//namespace Platformer397
namespace Platformer397 {

    [RequireComponent(typeof(NavMeshAgent))]
    //RoadAgent Class
    public class RoadAgent : MonoBehaviour, IAgent {

        [SerializeField, Self] private NavMeshAgent agent;
        private Vector3 target;

        //OnValidate Method
        private void OnValidate() { 
            this.ValidateRefs();
        } //End of OnValidate Method

        //FixedUpdate Method
        private void FixedUpdate() {

            if (Vector3.Distance(transform.position, target) < 1.5f) { 
                CompleteJob();
            }

        } //End of FixedUpdate Method

        //Navigate Method
        public void Navigate(Vector3 destination) {
            
            target = destination;
            agent.destination = target;

        } //End of Navigate Method

        //CompleteJob Method
        public void CompleteJob() {
            
            Debug.Log("Job Complete, Self-Destructing in 1.5 seconds");
            Destroy(gameObject, 1.5f);

        } //End of CompleteJob Method

    } //End of RoadAgent Class

} //End of namespace Platformer397
