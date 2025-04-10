using System.Collections;
using UnityEngine;


//namespace Platformer397
namespace Platformer397 {

    //RoadAgentFactory Method
    public class RoadAgentFactory : AbstractFactory {

        //private bool enableAgentGeneration = false;

        private IEnumerator routine;

        //Awake Method
        private void Awake() {
            routine = GeneratingAgents();
        }

        //Update Method
        private void Update() {

            if (Input.GetKeyDown(KeyCode.Space)) {
                StartCoroutine(routine);
            }

            if (Input.GetKeyDown(KeyCode.P)) {
                StopCoroutine(routine);
            }

        } //End of Update Method

        //DebugLater IEnumerator
        private IEnumerator GeneratingAgents() { 

            var wiatTime = new WaitForSeconds(2f);

            while (true) {
                GenerateAgent();
                yield return wiatTime;
            }

        } //End of DebugLater IEnumerator

        //GenerateAgent Method
        public override void GenerateAgent() {

            GameObject agent = Instantiate(agentPrefabs[0], spawnLocation.position, spawnLocation.rotation);
            agent.GetComponent<RoadAgent>().Navigate(spawnTarget.position);

        } //End of GenerateAgent Method

    } //End of RoadAgentFactory Method

} //End of namespace Platformer397
