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
        var relativePosition = humanoid.transform.position - guard.transform.position;
        var destination = guard.transform.position - relativePosition;
        navMeshAgent.SetDestination(destination);
        
    }
}
