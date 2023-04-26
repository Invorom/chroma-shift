using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrisonerMenuScript : MonoBehaviour
{
    public GameObject humanoid;
    public GameObject guard;

    // Update is called once per frame
    void Update()
    {
        var navMeshAgent = humanoid.GetComponent<NavMeshAgent>();
        navMeshAgent.avoidancePriority = 99;
        // humanoid go to opposite direction of guard
        navMeshAgent.SetDestination(humanoid.transform.position + (humanoid.transform.position - guard.transform.position));
    }
}
