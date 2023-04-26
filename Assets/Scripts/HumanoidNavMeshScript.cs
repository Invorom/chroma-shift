using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanoidNavMeshScript : MonoBehaviour
{
    private void Update()
    {
        // Get all the NavMeshAgents in the scene with tag "Humanoid"
        var humanoids = GameObject.FindGameObjectsWithTag("Humanoid");
        // Get all the NavMeshAgents components
        var navMeshAgents = new List<NavMeshAgent>();
        foreach (var humanoid in humanoids)
        {
            navMeshAgents.Add(humanoid.GetComponent<NavMeshAgent>());
        }

        // Set the destination of all the NavMeshAgents to the player position
        foreach (var navMeshAgent in navMeshAgents)
        {
            navMeshAgent.SetDestination(GameObject.FindWithTag("Player").transform.position);
            navMeshAgent.transform.LookAt(GameObject.FindWithTag("Player").transform);
        }
    }
}
