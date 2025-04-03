using System.Collections;
using UnityEngine;

namespace Platformer397
{
    public class RoadAgentFactory : AbstractFactory
    {
            private IEnumerator spawn;

        private void Awake()
        {
            spawn = GeneratingAgents();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(spawn);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                StopCoroutine(spawn);
            }
        }

        public IEnumerator GeneratingAgents()
        {
            var waitTime = new WaitForSeconds(2);
            while (true)
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
