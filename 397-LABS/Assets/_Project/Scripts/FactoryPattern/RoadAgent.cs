using UnityEngine;
using UnityEngine.AI;
using KBCore.Refs;

namespace Platformer397
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class RoadAgent : MonoBehaviour, IAgent
    {
        [SerializeField, Self] private NavMeshAgent agent;
        private Vector3 target;

        private void OnValidate()
        {
            this.ValidateRefs();
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, target) < 1.5f)
            {
                CompleteJob();
            }
        }
        
        public void Navigate(Vector3 destination)
        {
            target = destination;
            agent.destination = target;
        }

        public void CompleteJob()
        {
            Debug.Log("Job Completed. Self-destructing in 1.5sec.");
            Destroy(gameObject, 1.5f);
        }
    }
}
