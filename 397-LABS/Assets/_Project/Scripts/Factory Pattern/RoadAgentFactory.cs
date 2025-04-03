using System.Collections;
using UnityEngine;

namespace Platformer397
{
    public class RoadAgentFactory : AbstractFactory
    {

        private IEnumerator routine;

        private void Awake()
        {
            routine = GeneratingAgents();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(routine);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                StopCoroutine(routine);
            }
        }

        

        private IEnumerator GeneratingAgents()
        {
            var waitTime = new WaitForSeconds(2f);
            while ((true))
            {
                GenerateAgent();
                yield return waitTime;
            }
        }

        public override void GenerateAgent()
        {
            GameObject agent = Instantiate(agentPrefabs[0], spawnLocation.position, spawnLocation.rotation);
            agent.GetComponent<RoadAgent>().Navigate(spawnTarget.position);
        }

        
    }
}
